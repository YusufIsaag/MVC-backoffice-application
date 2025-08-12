using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static DataAccessLayer.Models.Order;

namespace KE03_INTDEV_SE_2_Base.Controllers
{
    public class OrdersController : Controller
    {
        private readonly StarWarsDbContext _context;
        private readonly EmailSender _emailSender;  // email sender toevoegen

        public OrdersController(StarWarsDbContext context, EmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        // GET: OrdersController
        public async Task<IActionResult> Index()
        {
            var orders = _context.Orders
                                .Include(o => o.Customer)  
                                .Include(o => o.Products)   
                                .ToList();
            return View(orders);
        }

        // GET: OrdersController/Details/5
        public ActionResult Details(int id)
        {
            var order = _context.Orders
                       .Include(o => o.Customer)
                       .Include(o => o.Products)
                       .FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        
        [HttpPost]
        public async Task<IActionResult> UpdateOrderStatus(int id, OrderStatus newStatus)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            order.Status = newStatus;

            if (newStatus == OrderStatus.Shipped)
            {
                order.ShippedDate = DateTime.Now;
            }
            else if (newStatus == OrderStatus.Processing)
            {
                order.DateProcessing = DateTime.Now;
            }

            _context.Update(order);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Status van bestelling #{order.Id} succesvol aangepast naar {newStatus}.";

            // Email sturen naar klant
            if (order.Customer != null && !string.IsNullOrEmpty(order.Customer.Email))
            {
                string senderName = "Star Wars Unlimited";
                string senderEmail = "yusufisaag@outlook.com";
                string toName = order.Customer.Name;
                string toEmail = order.Customer.Email;
                string subject = $"Update over uw bestelling #{order.Id}";
                string message = $"Beste {order.Customer.Name},\n\n" +
                    $"Uw bestelling met nummer {order.Id} is nu {order.Status}.\n\n" +
                    "Met vriendelijke groet,\nStar Wars Unlimited";

                await _emailSender.sendEmailAsync(senderName, senderEmail, toName, toEmail, subject, message);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
