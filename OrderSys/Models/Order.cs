using System.Collections.Generic;

namespace OrderSys.Models
{
    public class Order
    {
        public Order(int id, string u)
        {
            this.Id = id;
            this.Username = u;
        }
        public Order()
        {

        }
        public Order(string u)
        {
            this.Username = u;
        }
        public Order(string date, string time, string location, int amt, int ordererid)
        {
            this.Date = date;
            this.Time = time;
            this.Location = location;
            this.OrdererId = ordererid;
        }
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public int Amount { get; set; }
        public int OrdererId { get; set; }
        //public MenuChoice MenuChoice { get; set; }
        public string Username { get; set; }
        public List<Choice> Choices { get; set; }

    }
}