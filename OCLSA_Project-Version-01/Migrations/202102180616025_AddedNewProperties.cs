namespace OCLSA_Project_Version_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Types", "MaximumFsoValueFinal", c => c.Double(nullable: false));
            AddColumn("dbo.Types", "MinimumFsoValueFinal", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Types", "MinimumFsoValueFinal");
            DropColumn("dbo.Types", "MaximumFsoValueFinal");
        }
    }
}
