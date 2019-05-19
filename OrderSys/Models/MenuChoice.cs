using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderSys.Models
{
    public class MenuChoice
    {
        public MenuChoice(Menu m, List<Choice> c)
        {
            this.Menu = m;
            this.Choices = c;
        }
        public MenuChoice()
        {
        }
        public MenuChoice(int i,int j)
        {
            this.MenuId = i;
            this.ChoiceId = j;
        }

        public int Id { get; set; }
        public int ChoiceId { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public List<Choice> Choices { get; set; }
    }
}