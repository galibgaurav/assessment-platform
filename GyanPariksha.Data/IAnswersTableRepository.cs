using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GyanPariksha.Model;

namespace GyanPariksha.Data
{
    public interface IAnswersTableRepository
    {
        Task<bool> DeleteAnswers(Guid id);
        IEnumerable<Answers> Getanswers();
        Task<Answers> GetAnswers(Guid id);
        Task<Answers> PostAnswers(Answers answers);
        Task<Answers> PutAnswers(Guid id, Answers answers);
        bool AnswersExists(Guid id);
    }
}