namespace OrderSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Status", c => c.String());
            DropColumn("dbo.Orders", "Settle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Settle", c => c.String());
            DropColumn("dbo.Orders", "Status");
        }
    }
}
