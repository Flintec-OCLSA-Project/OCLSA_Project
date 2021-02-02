namespace OCLSA_Project_Version_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedIdFromLoadcellModel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.LoadCells");
            AlterColumn("dbo.LoadCells", "SerialNumber", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.LoadCells", "SerialNumber");
            DropColumn("dbo.LoadCells", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoadCells", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.LoadCells");
            AlterColumn("dbo.LoadCells", "SerialNumber", c => c.String(nullable: false));
            AddPrimaryKey("dbo.LoadCells", "Id");
        }
    }
}
