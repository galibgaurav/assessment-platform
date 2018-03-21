namespace GyanPariksha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitailMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionPapers", "Questions_questionId", "dbo.Questions");
            DropIndex("dbo.QuestionPapers", new[] { "Questions_questionId" });
            DropColumn("dbo.QuestionPapers", "Questions_questionId");
            DropTable("dbo.Questions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        questionId = c.String(nullable: false, maxLength: 128),
                        correctAnswer = c.String(),
                        hint = c.String(),
                    })
                .PrimaryKey(t => t.questionId);
            
            AddColumn("dbo.QuestionPapers", "Questions_questionId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.QuestionPapers", "Questions_questionId");
            AddForeignKey("dbo.QuestionPapers", "Questions_questionId", "dbo.Questions", "questionId", cascadeDelete: true);
        }
    }
}
