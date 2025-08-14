using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE03_INTDEV_SE_2_Base.Models;

public class Order
{
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    public int CustomerId { get; set; }
    
    public Customer Customer { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = new List<Product>();
    public OrderStatus Status { get; set; } = OrderStatus.Received;
    public DateTime? ShippedDate { get; set; }
    public DateTime DateProcessing { get; set; }

    public enum OrderStatus
    {
        Received,    
        Processing, 
        Shipped  
    }
}
