namespace OCLSA_Project_Version_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedNewFieldsInTypeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Types", "FrontCornerTrimValue", c => c.Double());
            AddColumn("dbo.Types", "BackCornerTrimValuer", c => c.Double());
            AddColumn("dbo.Types", "LeftCornerTrimValue", c => c.Double());
            AddColumn("dbo.Types", "RightCornerTrimValue", c => c.Double());
            AddColumn("dbo.Types", "FrontRightCornerTrimValue", c => c.Double());
            AddColumn("dbo.Types", "FrontLeftCornerTrimValue", c => c.Double());
            AddColumn("dbo.Types", "BackRightCornerTrimValue", c => c.Double());
            AddColumn("dbo.Types", "BackLeftCornerTrimValue", c => c.Double());
            AddColumn("dbo.Types", "CornerTrimValue", c => c.Double());
            DropColumn("dbo.Types", "FrontCorner");
            DropColumn("dbo.Types", "BackCorner");
            DropColumn("dbo.Types", "LeftCorner");
            DropColumn("dbo.Types", "RightCorner");
            DropColumn("dbo.Types", "DiagonalFrontRightCorner");
            DropColumn("dbo.Types", "DiagonalFrontLeftCorner");
            DropColumn("dbo.Types", "DiagonalBackRightCorner");
            DropColumn("dbo.Types", "DiagonalBackLeftCorner");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Types", "DiagonalBackLeftCorner", c => c.Double());
            AddColumn("dbo.Types", "DiagonalBackRightCorner", c => c.Double());
            AddColumn("dbo.Types", "DiagonalFrontLeftCorner", c => c.Double());
            AddColumn("dbo.Types", "DiagonalFrontRightCorner", c => c.Double());
            AddColumn("dbo.Types", "RightCorner", c => c.Double());
            AddColumn("dbo.Types", "LeftCorner", c => c.Double());
            AddColumn("dbo.Types", "BackCorner", c => c.Double());
            AddColumn("dbo.Types", "FrontCorner", c => c.Double());
            DropColumn("dbo.Types", "CornerTrimValue");
            DropColumn("dbo.Types", "BackLeftCornerTrimValue");
            DropColumn("dbo.Types", "BackRightCornerTrimValue");
            DropColumn("dbo.Types", "FrontLeftCornerTrimValue");
            DropColumn("dbo.Types", "FrontRightCornerTrimValue");
            DropColumn("dbo.Types", "RightCornerTrimValue");
            DropColumn("dbo.Types", "LeftCornerTrimValue");
            DropColumn("dbo.Types", "BackCornerTrimValuer");
            DropColumn("dbo.Types", "FrontCornerTrimValue");
        }
    }
}
