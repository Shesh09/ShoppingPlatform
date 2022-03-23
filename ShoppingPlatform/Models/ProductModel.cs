using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingPlatform.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        
        public int Price { get; set; }
        public int MyProperty { get; set; }
        public DateTime DateItWasOrdered { get; set; }
        public string Country { get; set; }
    }
}