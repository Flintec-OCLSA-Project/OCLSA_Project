namespace OCLSA_Project_Version_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedTrimmedLoadCellModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrimmedLoadCells", "Unbalance", c => c.Double(nullable: false));
            DropColumn("dbo.TrimmedLoadCells", "TrimmedFso");
            DropColumn("dbo.TrimmedLoadCells", "FactoredFso");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrimmedLoadCells", "FactoredFso", c => c.Double(nullable: false));
            AddColumn("dbo.TrimmedLoadCells", "TrimmedFso", c => c.Double(nullable: false));
            DropColumn("dbo.TrimmedLoadCells", "Unbalance");
        }
    }
}
