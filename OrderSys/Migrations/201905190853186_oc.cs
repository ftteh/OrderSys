namespace OrderSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restrictions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Oc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Restrictions");
        }
    }
}
