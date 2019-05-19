namespace OrderSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class e : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "MenuChoice_Id", c => c.Int());
            AlterColumn("dbo.Orders", "Date", c => c.String());
            AlterColumn("dbo.Orders", "Time", c => c.String());
            CreateIndex("dbo.Orders", "MenuChoice_Id");
            AddForeignKey("dbo.Orders", "MenuChoice_Id", "dbo.MenuChoices", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "MenuChoice_Id", "dbo.MenuChoices");
            DropIndex("dbo.Orders", new[] { "MenuChoice_Id" });
            AlterColumn("dbo.Orders", "Time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "MenuChoice_Id");
        }
    }
}
