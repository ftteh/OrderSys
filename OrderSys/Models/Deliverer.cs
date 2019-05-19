using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderSys.Models
{
    public class Deliverer
    {
        public int Id { get; set; }
        public string Pass { get; set; }
        public string Username { get; set; }
        public string PhoneNo { get; set; }

        public ICollection<Salary> Salaries { get; set; }
    }
}