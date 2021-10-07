using System;
using System.Collections.Generic;
using System.Text;

namespace Ristori.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryID { get; set; }

    }
}
