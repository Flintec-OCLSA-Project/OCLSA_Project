namespace OCLSA_Project_Version_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTypeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Types", "MinimumUnbalanceReading", c => c.Double(nullable: false));
            AddColumn("dbo.Types", "MinimumFsoReading", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Types", "MinimumFsoReading");
            DropColumn("dbo.Types", "MinimumUnbalanceReading");
        }
    }
}
