using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderSys.Models
{
    public class OrderChoice
    {

        public OrderChoice(Order m, List<Choice> c)
        {
            this.Order = m;
            this.Choices = c;
        }
        public OrderChoice()
        {
        }
        public OrderChoice(int i, int j)
        {
            this.OrderId = i;
            this.ChoiceId = j;
        }

        public int Id { get; set; }
        public int ChoiceId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public List<Choice> Choices { get; set; }
    }
}