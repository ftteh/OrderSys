namespace OrderSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oio : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Orderer_Id", "dbo.Orderers");
            DropIndex("dbo.Orders", new[] { "Orderer_Id" });
            RenameColumn(table: "dbo.Orders", name: "Orderer_Id", newName: "OrdererId");
            AlterColumn("dbo.Orders", "OrdererId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "OrdererId");
            AddForeignKey("dbo.Orders", "OrdererId", "dbo.Orderers", "Id", cascadeDelete: true);
            DropColumn("dbo.Orders", "OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "OrderId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "OrdererId", "dbo.Orderers");
            DropIndex("dbo.Orders", new[] { "OrdererId" });
            AlterColumn("dbo.Orders", "OrdererId", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "OrdererId", newName: "Orderer_Id");
            CreateIndex("dbo.Orders", "Orderer_Id");
            AddForeignKey("dbo.Orders", "Orderer_Id", "dbo.Orderers", "Id");
        }
    }
}
