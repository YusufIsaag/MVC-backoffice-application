using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE03_INTDEV_SE_2_Base.Models;

public class Product
{        
    public int ProductId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string ProductImageUrl { get; set; }


    public ICollection<Order> Orders { get; } = new List<Order>();
}
