namespace OCLSA_Project_Version_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedSpellingMistakeInTypeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Types", "BackCornerTrimValue", c => c.Double());
            DropColumn("dbo.Types", "BackCornerTrimValuer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Types", "BackCornerTrimValuer", c => c.Double());
            DropColumn("dbo.Types", "BackCornerTrimValue");
        }
    }
}
