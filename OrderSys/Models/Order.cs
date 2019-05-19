using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrderSys.Models
{
    public class Order
    {

        public int Id { get; set; }
        public string Date { get; set; }
        public string Time{ get; set; }
        public string Location { get; set; }
        public int Amount { get; set; }
       public MenuChoice MenuChoice { get; set; }

        public virtual ICollection<Choice> Choices { get; set; }
    }
}