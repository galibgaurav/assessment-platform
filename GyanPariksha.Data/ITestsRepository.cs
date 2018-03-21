using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GyanPariksha.Model;

namespace GyanPariksha.Data
{
    public interface ITestsRepository
    {
        Task<bool> DeleteTest(Guid id);
        IEnumerable<Test> Gettest();
        Task<Test> GetTest(Guid id);
        Task<Test> PostTest(Test test);
        Task<Test> PutTest(Guid id, Test test);
        bool TestExists(Guid id);
    }
}