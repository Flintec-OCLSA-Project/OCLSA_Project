namespace OCLSA_Project_Version_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFsoFactorToType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Types", "FsoFactor", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Types", "FsoFactor");
        }
    }
}
