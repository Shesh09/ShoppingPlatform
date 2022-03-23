using ShoppingPlatform.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingPlatform.Context
{
    public class ProductContext:DbContext
    {
        public ProductContext()
        {

        }
        public DbSet<ProductModel> Products { get; set; }
    }
}