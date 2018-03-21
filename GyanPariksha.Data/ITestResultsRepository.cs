using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GyanPariksha.Model;

namespace GyanPariksha.Data
{
    public interface ITestResultsRepository
    {
        Task<bool> DeleteTestResult(Guid id);
        IEnumerable<TestResult> GettestResult();
        Task<TestResult> GetTestResult(Guid id);
        Task<TestResult> PostTestResult(TestResult testResult);
        Task<TestResult> PutTestResult(Guid id, TestResult testResult);
        bool TestResultExists(Guid id);
    }
}