namespace SCOTUS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class execremove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Case", "BranchId", "dbo.ExecutiveBranch");
            DropIndex("dbo.Case", new[] { "BranchId" });
            DropColumn("dbo.Case", "ExecutiveBranchId");
            DropColumn("dbo.Case", "BranchId");
            DropTable("dbo.ExecutiveBranch");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ExecutiveBranch",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        President = c.String(nullable: false),
                        Party = c.String(nullable: false),
                        InaugurationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BranchId);
            
            AddColumn("dbo.Case", "BranchId", c => c.Int(nullable: false));
            AddColumn("dbo.Case", "ExecutiveBranchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Case", "BranchId");
            AddForeignKey("dbo.Case", "BranchId", "dbo.ExecutiveBranch", "BranchId", cascadeDelete: true);
        }
    }
}
