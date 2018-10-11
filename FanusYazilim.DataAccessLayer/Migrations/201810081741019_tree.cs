namespace FanusYazilim.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tree : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertisements", "Second", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertisements", "Second");
        }
    }
}
