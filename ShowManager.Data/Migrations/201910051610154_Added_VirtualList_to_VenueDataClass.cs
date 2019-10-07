namespace ShowManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_VirtualList_to_VenueDataClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArtistShowData", "Venue_VenueID", c => c.Int());
            CreateIndex("dbo.ArtistShowData", "Venue_VenueID");
            AddForeignKey("dbo.ArtistShowData", "Venue_VenueID", "dbo.Venue", "VenueID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArtistShowData", "Venue_VenueID", "dbo.Venue");
            DropIndex("dbo.ArtistShowData", new[] { "Venue_VenueID" });
            DropColumn("dbo.ArtistShowData", "Venue_VenueID");
        }
    }
}
