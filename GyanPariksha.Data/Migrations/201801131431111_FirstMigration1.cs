namespace GyanPariksha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tests", "TestSubjectId_Id", "dbo.TestSubjects");
            DropIndex("dbo.Tests", new[] { "TestSubjectId_Id" });
            AddColumn("dbo.Tests", "TestSubjectId", c => c.String(nullable: false));
            DropColumn("dbo.Tests", "TestSubjectId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tests", "TestSubjectId_Id", c => c.Guid(nullable: false));
            DropColumn("dbo.Tests", "TestSubjectId");
            CreateIndex("dbo.Tests", "TestSubjectId_Id");
            AddForeignKey("dbo.Tests", "TestSubjectId_Id", "dbo.TestSubjects", "Id", cascadeDelete: true);
        }
    }
}
