namespace ShowManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationCommented_Out_Unused_Properties_inDataClasses : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Artist", "UserID");
            DropColumn("dbo.Artist", "IsHeadliner");
            DropColumn("dbo.Venue", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Venue", "UserID", c => c.Guid(nullable: false));
            AddColumn("dbo.Artist", "IsHeadliner", c => c.Boolean(nullable: false));
            AddColumn("dbo.Artist", "UserID", c => c.Guid(nullable: false));
        }
    }
}
