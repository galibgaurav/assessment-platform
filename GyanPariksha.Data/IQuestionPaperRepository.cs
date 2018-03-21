using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GyanPariksha.Model;

namespace GyanPariksha.Data
{
    public interface IQuestionPaperRepository
    {
        Task<bool> DeleteQuestionPaper(Guid id);
        IEnumerable<QuestionPaper> GetquestionPaper();
        Task<QuestionPaper> GetQuestionPaper(Guid id);
        Task<QuestionPaper> PostQuestionPaper(QuestionPaper questionPaper);
        Task<QuestionPaper> PutQuestionPaper(Guid id, QuestionPaper questionPaper);
        bool QuestionPaperExists(Guid id);
    }
}