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

        public string DeliveryAddress { get; set; }

        public string DeliverySurname { get; set; }

        public string DeliveryPhone { get; set; }

        public TimeSpan DeliveryDateTime { get; set; }

    }
}
