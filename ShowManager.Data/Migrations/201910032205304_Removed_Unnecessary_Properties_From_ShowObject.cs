namespace ShowManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removed_Unnecessary_Properties_From_ShowObject : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Show", "VenueName");
            DropColumn("dbo.Show", "Location");
            DropColumn("dbo.Show", "VenueType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Show", "VenueType", c => c.Int(nullable: false));
            AddColumn("dbo.Show", "Location", c => c.String());
            AddColumn("dbo.Show", "VenueName", c => c.String());
        }
    }
}
