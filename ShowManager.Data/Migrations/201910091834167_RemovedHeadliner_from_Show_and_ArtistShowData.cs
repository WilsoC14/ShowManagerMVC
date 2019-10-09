namespace ShowManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedHeadliner_from_Show_and_ArtistShowData : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ArtistShowData", "IsHeadLiner");
            DropColumn("dbo.Show", "HeadLiningArtist");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Show", "HeadLiningArtist", c => c.String());
            AddColumn("dbo.ArtistShowData", "IsHeadLiner", c => c.Boolean(nullable: false));
        }
    }
}
