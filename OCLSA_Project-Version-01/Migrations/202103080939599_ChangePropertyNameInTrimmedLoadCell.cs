namespace OCLSA_Project_Version_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePropertyNameInTrimmedLoadCell : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrimmedLoadCells", "CalculatedFso", c => c.Double(nullable: false));
            DropColumn("dbo.TrimmedLoadCells", "Unbalance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrimmedLoadCells", "Unbalance", c => c.Double(nullable: false));
            DropColumn("dbo.TrimmedLoadCells", "CalculatedFso");
        }
    }
}
