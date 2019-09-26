namespace ShowManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedArtistForeignKeyFromShow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Show", "ArtistID", "dbo.Artist");
            DropIndex("dbo.Show", new[] { "ArtistID" });
            CreateTable(
                "dbo.ArtistShowData",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        ArtistID = c.Int(nullable: false),
                        ArtistName = c.String(nullable: false),
                        IsHeadLiner = c.Boolean(nullable: false),
                        ShowID = c.Int(nullable: false),
                        ShowName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Artist", t => t.ArtistID, cascadeDelete: true)
                .ForeignKey("dbo.Show", t => t.ShowID, cascadeDelete: true)
                .Index(t => t.ArtistID)
                .Index(t => t.ShowID);
            
            DropColumn("dbo.Show", "ArtistID");
            DropColumn("dbo.Show", "ArtistName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Show", "ArtistName", c => c.String());
            AddColumn("dbo.Show", "ArtistID", c => c.Int(nullable: false));
            DropForeignKey("dbo.ArtistShowData", "ShowID", "dbo.Show");
            DropForeignKey("dbo.ArtistShowData", "ArtistID", "dbo.Artist");
            DropIndex("dbo.ArtistShowData", new[] { "ShowID" });
            DropIndex("dbo.ArtistShowData", new[] { "ArtistID" });
            DropTable("dbo.ArtistShowData");
            CreateIndex("dbo.Show", "ArtistID");
            AddForeignKey("dbo.Show", "ArtistID", "dbo.Artist", "ArtistID", cascadeDelete: true);
        }
    }
}
