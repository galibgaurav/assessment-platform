using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GyanPariksha.Model;

namespace GyanPariksha.Data
{
    public interface ITestTakensRepository
    {
        Task<bool> DeleteTestTaken(Guid id);
        IEnumerable<TestTaken> GettestTaken();
        Task<TestTaken> GetTestTaken(Guid id);
        Task<TestTaken> PostTestTaken(TestTaken testTaken);
        Task<TestTaken> PutTestTaken(Guid id, TestTaken testTaken);
        bool TestTakenExists(Guid id);
    }
}