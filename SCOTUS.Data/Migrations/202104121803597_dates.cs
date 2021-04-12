namespace SCOTUS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Case", "CaseYear", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Case", "CaseYear", c => c.DateTime(nullable: false));
        }
    }
}
