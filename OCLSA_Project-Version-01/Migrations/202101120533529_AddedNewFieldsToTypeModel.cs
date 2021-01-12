namespace OCLSA_Project_Version_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewFieldsToTypeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Types", "MaximumCenterValue", c => c.Double(nullable: false));
            AddColumn("dbo.Types", "ExcessiveCornerValue", c => c.Double(nullable: false));
            AddColumn("dbo.Types", "LeftRightCornerDifference", c => c.Double(nullable: false));
            AddColumn("dbo.Types", "FrontBackCornerDifference", c => c.Double(nullable: false));
            AddColumn("dbo.Types", "MaximumUnbalanceValue", c => c.Double(nullable: false));
            AddColumn("dbo.Types", "MinimumUnbalanceValue", c => c.Double(nullable: false));
            AddColumn("dbo.Types", "MaximumFsoValue", c => c.Double(nullable: false));
            AddColumn("dbo.Types", "MinimumFsoValue", c => c.Double(nullable: false));
            DropColumn("dbo.Types", "MaximumCenterReading");
            DropColumn("dbo.Types", "MaximumUnbalanceReading");
            DropColumn("dbo.Types", "MinimumUnbalanceReading");
            DropColumn("dbo.Types", "MaximumFsoReading");
            DropColumn("dbo.Types", "MinimumFsoReading");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Types", "MinimumFsoReading", c => c.Double(nullable: false));
            AddColumn("dbo.Types", "MaximumFsoReading", c => c.Double(nullable: false));
            AddColumn("dbo.Types", "MinimumUnbalanceReading", c => c.Double(nullable: false));
            AddColumn("dbo.Types", "MaximumUnbalanceReading", c => c.Double(nullable: false));
            AddColumn("dbo.Types", "MaximumCenterReading", c => c.Double(nullable: false));
            DropColumn("dbo.Types", "MinimumFsoValue");
            DropColumn("dbo.Types", "MaximumFsoValue");
            DropColumn("dbo.Types", "MinimumUnbalanceValue");
            DropColumn("dbo.Types", "MaximumUnbalanceValue");
            DropColumn("dbo.Types", "FrontBackCornerDifference");
            DropColumn("dbo.Types", "LeftRightCornerDifference");
            DropColumn("dbo.Types", "ExcessiveCornerValue");
            DropColumn("dbo.Types", "MaximumCenterValue");
        }
    }
}
