using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderSys.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }
}