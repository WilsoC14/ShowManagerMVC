namespace ShowManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsHeadliner_bool_inArtistShowData_and_HeadliningArtist_string_inShow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArtistShowData", "IsHeadLiner", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArtistShowData", "IsHeadLiner");
        }
    }
}
