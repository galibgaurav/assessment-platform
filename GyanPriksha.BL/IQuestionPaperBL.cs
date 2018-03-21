using System.Collections.Generic;
using GyanPariksha.Model;
namespace GyanPriksha.BL
{
    public interface IQuestionPaperBL
    {
        bool WriteQuestionPaper(IList<QuestionEntity> Questions,string testID);
        string ReadQuestionPaper(string QuestionPaperID, string testID);
        
    }
}