namespace OCLSA_Project_Version_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrimmedLoadCells",
                c => new
                    {
                        SerialNumber = c.String(nullable: false, maxLength: 128),
                        LoadCellType = c.String(nullable: false),
                        StartingTime = c.DateTime(nullable: false),
                        EndingTime = c.DateTime(nullable: false),
                        BridgeUnbalance = c.Double(nullable: false),
                        InitialFso = c.Double(nullable: false),
                        InitialLeftCorner = c.Double(nullable: false),
                        InitialD1Corner = c.Double(nullable: false),
                        InitialBackCorner = c.Double(nullable: false),
                        InitialD2Corner = c.Double(nullable: false),
                        InitialRightCorner = c.Double(nullable: false),
                        InitialD3Corner = c.Double(nullable: false),
                        InitialFrontCorner = c.Double(nullable: false),
                        InitialD4Corner = c.Double(nullable: false),
                        FinalLeftCorner = c.Double(nullable: false),
                        FinalD1Corner = c.Double(nullable: false),
                        FinalBackCorner = c.Double(nullable: false),
                        FinalD2Corner = c.Double(nullable: false),
                        FinalRightCorner = c.Double(nullable: false),
                        FinalD3Corner = c.Double(nullable: false),
                        FinalFrontCorner = c.Double(nullable: false),
                        FinalD4Corner = c.Double(nullable: false),
                        TrimmedFso = c.Double(nullable: false),
                        FactoredFso = c.Double(nullable: false),
                        FinalFso = c.Double(nullable: false),
                        Status = c.String(nullable: false),
                        RejectCriteria = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SerialNumber);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TrimmedLoadCells");
        }
    }
}
