namespace ShowManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removed_propertyFrom_previousMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Artist", "Show_ShowID", "dbo.Show");
            DropIndex("dbo.Artist", new[] { "Show_ShowID" });
            DropColumn("dbo.Artist", "Show_ShowID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artist", "Show_ShowID", c => c.Int());
            CreateIndex("dbo.Artist", "Show_ShowID");
            AddForeignKey("dbo.Artist", "Show_ShowID", "dbo.Show", "ShowID");
        }
    }
}
