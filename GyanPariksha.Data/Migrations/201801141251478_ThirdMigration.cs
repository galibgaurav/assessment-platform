namespace GyanPariksha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionEntities",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        question = c.String(),
                        keyChoice = c.String(),
                        hint = c.String(),
                        QuestionPaper_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.QuestionPapers", t => t.QuestionPaper_Id)
                .Index(t => t.QuestionPaper_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionEntities", "QuestionPaper_Id", "dbo.QuestionPapers");
            DropIndex("dbo.QuestionEntities", new[] { "QuestionPaper_Id" });
            DropTable("dbo.QuestionEntities");
        }
    }
}
