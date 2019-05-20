namespace OrderSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_oc_model1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.OrderChoices", newName: "OrderChoice1");
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
            
            AddColumn("dbo.Choices", "OrderChoice_Id", c => c.Int());
            CreateIndex("dbo.Choices", "OrderChoice_Id");
            AddForeignKey("dbo.Choices", "OrderChoice_Id", "dbo.OrderChoices", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderChoices", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Choices", "OrderChoice_Id", "dbo.OrderChoices");
            DropIndex("dbo.OrderChoices", new[] { "OrderId" });
            DropIndex("dbo.Choices", new[] { "OrderChoice_Id" });
            DropColumn("dbo.Choices", "OrderChoice_Id");
            DropTable("dbo.OrderChoices");
            RenameTable(name: "dbo.OrderChoice1", newName: "OrderChoices");
        }
    }
}
