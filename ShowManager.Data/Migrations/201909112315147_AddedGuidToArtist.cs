namespace ShowManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGuidToArtist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artist", "UserID", c => c.Guid(nullable: false));
            AddColumn("dbo.Artist", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artist", "Location");
            DropColumn("dbo.Artist", "UserID");
        }
    }
}
