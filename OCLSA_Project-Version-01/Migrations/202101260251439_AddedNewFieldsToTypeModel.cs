namespace OCLSA_Project_Version_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewFieldsToTypeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Types", "AppliedLoad", c => c.Double(nullable: false));
            AddColumn("dbo.Types", "Capacity", c => c.Double(nullable: false));
            AddColumn("dbo.Types", "Factor", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Types", "Factor");
            DropColumn("dbo.Types", "Capacity");
            DropColumn("dbo.Types", "AppliedLoad");
        }
    }
}
