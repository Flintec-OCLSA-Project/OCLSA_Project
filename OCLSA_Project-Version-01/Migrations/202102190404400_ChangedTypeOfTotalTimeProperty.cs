namespace OCLSA_Project_Version_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTypeOfTotalTimeProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrimmedLoadCells", "TotalTime", c => c.String(nullable: false));
            DropColumn("dbo.TrimmedLoadCells", "TotalTimeInMinutes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrimmedLoadCells", "TotalTimeInMinutes", c => c.Int(nullable: false));
            DropColumn("dbo.TrimmedLoadCells", "TotalTime");
        }
    }
}
