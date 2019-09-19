namespace ShowManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedVenueCrud : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Venue",
                c => new
                    {
                        VenueID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        VenueName = c.String(nullable: false),
                        VenueType = c.Int(nullable: false),
                        Location = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.VenueID);
            
            AlterColumn("dbo.Artist", "ArtistName", c => c.String(nullable: false));
            AlterColumn("dbo.Artist", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artist", "Location", c => c.String());
            AlterColumn("dbo.Artist", "ArtistName", c => c.String());
            DropTable("dbo.Venue");
        }
    }
}
