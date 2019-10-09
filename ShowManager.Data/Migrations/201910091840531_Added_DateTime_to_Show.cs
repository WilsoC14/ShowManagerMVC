namespace ShowManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_DateTime_to_Show : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Show", "DateOfShow", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Show", "DateOfShow");
        }
    }
}
