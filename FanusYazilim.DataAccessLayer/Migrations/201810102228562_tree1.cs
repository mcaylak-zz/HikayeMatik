namespace FanusYazilim.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tree1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "CategoryImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "CategoryImageUrl", c => c.String());
        }
    }
}
