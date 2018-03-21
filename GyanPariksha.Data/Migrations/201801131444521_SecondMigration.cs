namespace GyanPariksha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tests", "PositiveMark", c => c.String(nullable: false));
            AlterColumn("dbo.Tests", "NegativeMark", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tests", "NegativeMark", c => c.Int(nullable: false));
            AlterColumn("dbo.Tests", "PositiveMark", c => c.Int(nullable: false));
        }
    }
}
