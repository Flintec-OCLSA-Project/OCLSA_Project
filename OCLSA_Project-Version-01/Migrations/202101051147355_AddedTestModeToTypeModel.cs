namespace OCLSA_Project_Version_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTestModeToTypeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Types", "TestMode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Types", "TestMode");
        }
    }
}
