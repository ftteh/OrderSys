namespace OrderSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class auth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orderers", "Username", c => c.String());
            AddColumn("dbo.Orderers", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orderers", "Role");
            DropColumn("dbo.Orderers", "Username");
        }
    }
}
