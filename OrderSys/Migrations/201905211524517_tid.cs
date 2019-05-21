namespace OrderSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Settle", c => c.String());
            DropTable("dbo.Sales");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Orders", "Settle");
        }
    }
}
