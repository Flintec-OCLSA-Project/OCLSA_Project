namespace OCLSA_Project_Version_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewPropertiesToTrimmedLoadCellModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrimmedLoadCells", "Operator", c => c.String(nullable: false));
            AddColumn("dbo.TrimmedLoadCells", "OperatorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrimmedLoadCells", "OperatorId");
            DropColumn("dbo.TrimmedLoadCells", "Operator");
        }
    }
}
