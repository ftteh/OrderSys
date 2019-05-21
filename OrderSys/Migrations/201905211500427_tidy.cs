namespace OrderSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tidy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Salaries", "Deliverer_Id", "dbo.Deliverers");
            DropIndex("dbo.Salaries", new[] { "Deliverer_Id" });
            DropColumn("dbo.Orders", "Username");
            DropTable("dbo.Deliverers");
            DropTable("dbo.Salaries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Deliverer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Deliverers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pass = c.String(),
                        Username = c.String(),
                        PhoneNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "Username", c => c.String());
            CreateIndex("dbo.Salaries", "Deliverer_Id");
            AddForeignKey("dbo.Salaries", "Deliverer_Id", "dbo.Deliverers", "Id");
        }
    }
}
