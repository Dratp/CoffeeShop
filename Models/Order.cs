using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShop.Models
{
    public class Order
    {
        public WebUser Person { get; set; }
        public List<Item> Stuff { get; set; }
        public bool Delivery { get; set; }
        public DateTime Time { get; set; }


    }
}