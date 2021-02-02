namespace OCLSA_Project_Version_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFSOCorrectionValueField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoadCells", "MetalCategory", c => c.String(nullable: false));
            AddColumn("dbo.Types", "FsoCorrectionValue", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Types", "FsoCorrectionValue");
            DropColumn("dbo.LoadCells", "MetalCategory");
        }
    }
}
