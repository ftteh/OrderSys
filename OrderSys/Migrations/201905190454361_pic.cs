namespace OrderSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Choices", "Pic", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Choices", "Pic");
        }
    }
}
