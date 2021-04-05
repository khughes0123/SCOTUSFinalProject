namespace SCOTUS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Case", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Case", "CaseYear", c => c.DateTime(nullable: false));
            DropColumn("dbo.Case", "OwnerId");
            DropColumn("dbo.Case", "Year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Case", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.Case", "OwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Case", "CaseYear");
            DropColumn("dbo.Case", "UserId");
        }
    }
}
