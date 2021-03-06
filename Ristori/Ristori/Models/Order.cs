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
        public string Note { get; set; }
        public string ComandaTavolo { get; set; }

        public string DeliveryAddress { get; set; }

        public string DeliverySurname { get; set; }

        public string DeliveryPhone { get; set; }

        public DateTime OrderMakedDate { get; set; }
        public TimeSpan OrderMakedTime { get; set; }
        public DateTime DeliveryDate { get; set; }
        public TimeSpan DeliveryDateTime { get; set; }
        

        public Order()
        {
            this.DeliveryDate = DateTime.Now;
            this.DeliveryDateTime = new TimeSpan(18, 45, 00);
        }

    }
}
