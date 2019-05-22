using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderSys.Models
{
    public class Orderer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string College { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}