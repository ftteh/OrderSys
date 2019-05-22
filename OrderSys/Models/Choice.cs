using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderSys.Models
{
    public class Choice
    {

        public int Id { get; set; }
        public string Item { get; set; }
        public int Price{ get; set; }
        public String Pic{ get; set; }
        public string description { get; set; }
        public virtual ICollection<Menu> Menus { set; get; }
        public virtual ICollection<Order> Orders { set; get; }

    }
}