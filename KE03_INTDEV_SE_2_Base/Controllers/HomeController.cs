using System.Diagnostics;
using KE03_INTDEV_SE_2_Base.Models;
using KE03_INTDEV_SE_2_Base.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static KE03_INTDEV_SE_2_Base.Models.Order;

namespace KE03_INTDEV_SE_2_Base.Controllers
{
    public class HomeController : Controller
{
    private readonly StarWarsDbContext _context;

    public HomeController(StarWarsDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.NewOrdersCount = _context.Orders.Count(o => o.Status == OrderStatus.Received);
        ViewBag.ProcessingCount = _context.Orders.Count(o => o.Status == OrderStatus.Processing);
        ViewBag.ShippedCount = _context.Orders.Count(o => o.Status == OrderStatus.Shipped);
        
        ViewBag.RecentOrders = _context.Orders
            .Include(o => o.Customer)
            .OrderByDescending(o => o.OrderDate)
            .Take(5)
            .ToList();

        return View();
    }


        public IActionResult Privacy()
        {
            return View();
        }

    }
}
