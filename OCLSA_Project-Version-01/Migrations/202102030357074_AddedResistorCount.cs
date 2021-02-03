namespace OCLSA_Project_Version_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedResistorCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrimmedLoadCells", "NoOfResistors", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrimmedLoadCells", "NoOfResistors");
        }
    }
}
