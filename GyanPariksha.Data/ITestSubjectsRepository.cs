using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GyanPariksha.Model;

namespace GyanPariksha.Data
{
    public interface ITestSubjectsRepository
    {
        Task<bool> DeleteTestSubject(Guid id);
        IEnumerable<TestSubject> GetTestSubject();
        Task<TestSubject> GetTestSubject(Guid id);
        Task<TestSubject> PostTestSubject(TestSubject testSubject);
        Task<TestSubject> PutTestSubject(Guid id, TestSubject testSubject);
        bool TestSubjectExists(Guid id);
    }
}