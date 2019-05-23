namespace OrderSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
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
                        description = c.String(),
                        MenuChoice_Id = c.Int(),
                        OrderChoice_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuChoices", t => t.MenuChoice_Id)
                .ForeignKey("dbo.OrderChoices", t => t.OrderChoice_Id)
                .Index(t => t.MenuChoice_Id)
                .Index(t => t.OrderChoice_Id);
            
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
                        OrdererId = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orderers", t => t.OrdererId, cascadeDelete: true)
                .Index(t => t.OrdererId);
            
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
                "dbo.OrderChoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChoiceId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orderers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNo = c.String(),
                        College = c.String(),
                        Password = c.String(),
                        Username = c.String(),
                        Role = c.String(),
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
                "dbo.OrderChoice1",
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
            DropForeignKey("dbo.Orders", "OrdererId", "dbo.Orderers");
            DropForeignKey("dbo.OrderChoices", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Choices", "OrderChoice_Id", "dbo.OrderChoices");
            DropForeignKey("dbo.MenuChoices", "MenuId", "dbo.Menus");
            DropForeignKey("dbo.Choices", "MenuChoice_Id", "dbo.MenuChoices");
            DropForeignKey("dbo.OrderChoice1", "Choice_Id", "dbo.Choices");
            DropForeignKey("dbo.OrderChoice1", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.MenuChoice1", "Choice_Id", "dbo.Choices");
            DropForeignKey("dbo.MenuChoice1", "Menu_Id", "dbo.Menus");
            DropIndex("dbo.OrderChoice1", new[] { "Choice_Id" });
            DropIndex("dbo.OrderChoice1", new[] { "Order_Id" });
            DropIndex("dbo.MenuChoice1", new[] { "Choice_Id" });
            DropIndex("dbo.MenuChoice1", new[] { "Menu_Id" });
            DropIndex("dbo.OrderChoices", new[] { "OrderId" });
            DropIndex("dbo.MenuChoices", new[] { "MenuId" });
            DropIndex("dbo.Orders", new[] { "OrdererId" });
            DropIndex("dbo.Choices", new[] { "OrderChoice_Id" });
            DropIndex("dbo.Choices", new[] { "MenuChoice_Id" });
            DropTable("dbo.OrderChoice1");
            DropTable("dbo.MenuChoice1");
            DropTable("dbo.Orderers");
            DropTable("dbo.OrderChoices");
            DropTable("dbo.Restrictions");
            DropTable("dbo.MenuChoices");
            DropTable("dbo.Orders");
            DropTable("dbo.Menus");
            DropTable("dbo.Choices");
        }
    }
}
