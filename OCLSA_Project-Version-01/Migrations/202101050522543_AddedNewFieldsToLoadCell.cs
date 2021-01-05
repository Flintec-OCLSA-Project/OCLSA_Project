namespace OCLSA_Project_Version_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewFieldsToLoadCell : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Types", "FrontCorner", c => c.Double());
            AddColumn("dbo.Types", "BackCorner", c => c.Double());
            AddColumn("dbo.Types", "LeftCorner", c => c.Double());
            AddColumn("dbo.Types", "RightCorner", c => c.Double());
            AddColumn("dbo.Types", "DiagonalFrontRightCorner", c => c.Double());
            AddColumn("dbo.Types", "DiagonalFrontLeftCorner", c => c.Double());
            AddColumn("dbo.Types", "DiagonalBackRightCorner", c => c.Double());
            AddColumn("dbo.Types", "DiagonalBackLeftCorner", c => c.Double());
            AddColumn("dbo.Types", "MaximumUnbalanceReading", c => c.Double(nullable: false));
            AddColumn("dbo.Types", "MaximumFsoReading", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Types", "MaximumFsoReading");
            DropColumn("dbo.Types", "MaximumUnbalanceReading");
            DropColumn("dbo.Types", "DiagonalBackLeftCorner");
            DropColumn("dbo.Types", "DiagonalBackRightCorner");
            DropColumn("dbo.Types", "DiagonalFrontLeftCorner");
            DropColumn("dbo.Types", "DiagonalFrontRightCorner");
            DropColumn("dbo.Types", "RightCorner");
            DropColumn("dbo.Types", "LeftCorner");
            DropColumn("dbo.Types", "BackCorner");
            DropColumn("dbo.Types", "FrontCorner");
        }
    }
}
