using System.Data.Entity;

namespace OrderSys.Models
{
    public class AllContext : DbContext
    {
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Orderer> Orderers { get; set; }
        public DbSet<MenuChoice> MenuChoices { get; set; }
        public DbSet<OrderChoice> OrderChoices { get; set; }
        public DbSet<Restriction> Oc { get; set; }
    }
}