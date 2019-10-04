namespace ShowManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Commented_Out_IsHeadliner : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ArtistShowData", "IsHeadLiner");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArtistShowData", "IsHeadLiner", c => c.Boolean(nullable: false));
        }
    }
}
