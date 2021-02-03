namespace OCLSA_Project_Version_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFsoCorrectionField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrimmedLoadCells", "IsFsoCorrectionAvailable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrimmedLoadCells", "IsFsoCorrectionAvailable");
        }
    }
}
