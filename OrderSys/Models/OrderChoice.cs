using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderSys.Models
{
    public class OrderChoice
    {
        public int Id { get; set; }
        public IEnumerable<Order> Orders{ get; set; }
        public IEnumerable<Choice> Choices { get; set; }
    }
}