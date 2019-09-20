namespace ShowManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedShowCrud : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Show",
                c => new
                    {
                        ShowID = c.Int(nullable: false, identity: true),
                        ShowName = c.String(nullable: false),
                        VenueID = c.Int(nullable: false),
                        VenueName = c.String(),
                        Location = c.String(),
                        VenueType = c.Int(nullable: false),
                        ArtistID = c.Int(nullable: false),
                        ArtistName = c.String(),
                        HeadLiningArtist = c.String(),
                    })
                .PrimaryKey(t => t.ShowID)
                .ForeignKey("dbo.Artist", t => t.ArtistID, cascadeDelete: true)
                .ForeignKey("dbo.Venue", t => t.VenueID, cascadeDelete: true)
                .Index(t => t.VenueID)
                .Index(t => t.ArtistID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Show", "VenueID", "dbo.Venue");
            DropForeignKey("dbo.Show", "ArtistID", "dbo.Artist");
            DropIndex("dbo.Show", new[] { "ArtistID" });
            DropIndex("dbo.Show", new[] { "VenueID" });
            DropTable("dbo.Show");
        }
    }
}
