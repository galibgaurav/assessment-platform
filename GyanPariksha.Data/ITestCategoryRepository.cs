using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GyanPariksha.Model;

namespace GyanPariksha.Data
{
    public interface ITestCategoryRepository
    {
        Task<bool> DeleteTestCategory(Guid id);
        IEnumerable<TestCategory> GetTestCategory();
        Task<TestCategory> GetTestCategory(Guid id);
        Task<TestCategory> PostTestCategory(TestCategory testCategory);
        Task<TestCategory> PutTestCategory(Guid id, TestCategory testCategory);
        bool TestCategoryExists(Guid id);
    }
}