namespace ShowManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_ListOfArtist_toShowData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artist", "Show_ShowID", c => c.Int());
            CreateIndex("dbo.Artist", "Show_ShowID");
            AddForeignKey("dbo.Artist", "Show_ShowID", "dbo.Show", "ShowID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Artist", "Show_ShowID", "dbo.Show");
            DropIndex("dbo.Artist", new[] { "Show_ShowID" });
            DropColumn("dbo.Artist", "Show_ShowID");
        }
    }
}
