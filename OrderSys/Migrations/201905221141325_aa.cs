namespace OrderSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Choices", "description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Choices", "description");
        }
    }
}
