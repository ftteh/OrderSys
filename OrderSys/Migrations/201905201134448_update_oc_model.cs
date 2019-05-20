namespace OrderSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_oc_model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Choices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Item = c.String(),
                        Price = c.Int(nullable: false),
                        Pic = c.String(),
                        MenuChoice_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuChoices", t => t.MenuChoice_Id)
                .Index(t => t.MenuChoice_Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Time = c.String(),
                        Location = c.String(),
                        Amount = c.Int(nullable: false),
                        Username = c.String(),
                        Orderer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orderers", t => t.Orderer_Id)
                .Index(t => t.Orderer_Id);
            
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
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Deliverer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deliverers", t => t.Deliverer_Id)
                .Index(t => t.Deliverer_Id);
            
            CreateTable(
                "dbo.MenuChoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChoiceId = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId);
            
            CreateTable(
                "dbo.Restrictions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Oc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orderers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNo = c.String(),
                        College = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pass = c.String(),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuChoice1",
                c => new
                    {
                        Menu_Id = c.Int(nullable: false),
                        Choice_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Menu_Id, t.Choice_Id })
                .ForeignKey("dbo.Menus", t => t.Menu_Id, cascadeDelete: true)
                .ForeignKey("dbo.Choices", t => t.Choice_Id, cascadeDelete: true)
                .Index(t => t.Menu_Id)
                .Index(t => t.Choice_Id);
            
            CreateTable(
                "dbo.OrderChoices",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Choice_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Choice_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Choices", t => t.Choice_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Choice_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Orderer_Id", "dbo.Orderers");
            DropForeignKey("dbo.MenuChoices", "MenuId", "dbo.Menus");
            DropForeignKey("dbo.Choices", "MenuChoice_Id", "dbo.MenuChoices");
            DropForeignKey("dbo.Salaries", "Deliverer_Id", "dbo.Deliverers");
            DropForeignKey("dbo.OrderChoices", "Choice_Id", "dbo.Choices");
            DropForeignKey("dbo.OrderChoices", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.MenuChoice1", "Choice_Id", "dbo.Choices");
            DropForeignKey("dbo.MenuChoice1", "Menu_Id", "dbo.Menus");
            DropIndex("dbo.OrderChoices", new[] { "Choice_Id" });
            DropIndex("dbo.OrderChoices", new[] { "Order_Id" });
            DropIndex("dbo.MenuChoice1", new[] { "Choice_Id" });
            DropIndex("dbo.MenuChoice1", new[] { "Menu_Id" });
            DropIndex("dbo.MenuChoices", new[] { "MenuId" });
            DropIndex("dbo.Salaries", new[] { "Deliverer_Id" });
            DropIndex("dbo.Orders", new[] { "Orderer_Id" });
            DropIndex("dbo.Choices", new[] { "MenuChoice_Id" });
            DropTable("dbo.OrderChoices");
            DropTable("dbo.MenuChoice1");
            DropTable("dbo.Sales");
            DropTable("dbo.Owners");
            DropTable("dbo.Orderers");
            DropTable("dbo.Restrictions");
            DropTable("dbo.MenuChoices");
            DropTable("dbo.Salaries");
            DropTable("dbo.Deliverers");
            DropTable("dbo.Orders");
            DropTable("dbo.Menus");
            DropTable("dbo.Choices");
        }
    }
}
