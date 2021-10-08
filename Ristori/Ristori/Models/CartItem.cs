using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ristori.Models
{
    [Table("CartProduct")]
    public class CartItem
    {
        [AutoIncrement, PrimaryKey]
        public int CartItemID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
