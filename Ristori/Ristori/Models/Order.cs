using System;
using System.Collections.Generic;
using System.Text;

namespace Ristori.Models
{
    public class Order
    {

        public string OrderID { get; set; }
        public string Username { get; set; }
        public decimal TotalCost { get; set; }

        public string deliveryAddress { get; set; }

        public string deliverySurname { get; set; }

        public string deliveryPhone { get; set; }

    }
}
