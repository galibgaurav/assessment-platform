namespace GyanPariksha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestSubjects", "TestCategoryId_Id", "dbo.TestCategories");
            DropIndex("dbo.TestSubjects", new[] { "TestCategoryId_Id" });
            AddColumn("dbo.TestSubjects", "TestCategoryId", c => c.String(nullable: false));
            DropColumn("dbo.TestSubjects", "TestCategoryId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestSubjects", "TestCategoryId_Id", c => c.Guid(nullable: false));
            DropColumn("dbo.TestSubjects", "TestCategoryId");
            CreateIndex("dbo.TestSubjects", "TestCategoryId_Id");
            AddForeignKey("dbo.TestSubjects", "TestCategoryId_Id", "dbo.TestCategories", "Id", cascadeDelete: true);
        }
    }
}
