using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderSys.Models
{
    public class Menu
    {

        public Menu(int id, DateTime d)
        {
            this.Id = id;
            this.Date = d;
        }

        public Menu()
        {

        }
        public Menu(DateTime d){
            this.Date = d;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Choice> Choices { get; set; }
    }
}