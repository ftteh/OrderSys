namespace OrderSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderId");
        }
    }
}
