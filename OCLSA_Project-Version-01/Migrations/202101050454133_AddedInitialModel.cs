namespace OCLSA_Project_Version_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoadCells",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SerialNumber = c.String(nullable: false),
                        TypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Types", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                        MaximumCenterReading = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoadCells", "TypeId", "dbo.Types");
            DropIndex("dbo.LoadCells", new[] { "TypeId" });
            DropTable("dbo.Types");
            DropTable("dbo.LoadCells");
        }
    }
}
