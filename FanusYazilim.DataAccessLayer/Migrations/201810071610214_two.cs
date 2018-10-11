namespace FanusYazilim.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class two : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CategoryImageUrl");
        }
    }
}
