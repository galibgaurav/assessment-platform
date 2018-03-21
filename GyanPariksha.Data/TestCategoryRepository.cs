using GyanPariksha.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyanPariksha.Data
{
    public class TestCategoryRepository : IDisposable, ITestCategoryRepository
    {
        private GyanParikshaDBContext db;
        public TestCategoryRepository(GyanParikshaDBContext _db)
        {
            db = _db;
        }

        public IEnumerable<TestCategory> GetTestCategory()
        {
            return db.testCategory;
        }

        public async Task<TestCategory> GetTestCategory(Guid id)
        {
            var testCategory = await db.testCategory.FindAsync(id);
            return testCategory;
        }

        public async Task<TestCategory> PutTestCategory(Guid id, TestCategory testCategory)
        {
            db.Entry(testCategory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            return testCategory;
        }

        public async Task<TestCategory> PostTestCategory(TestCategory testCategory)
        {
            db.testCategory.Add(testCategory);
            await db.SaveChangesAsync();
            return testCategory;
        }

        public async Task<bool> DeleteTestCategory(Guid id)
        {
            TestCategory testCategory = await db.testCategory.FindAsync(id);
            try {
                db.testCategory.Remove(testCategory);
                await db.SaveChangesAsync();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        
        public bool TestCategoryExists(Guid id)
        {
            return db.testCategory.Count(e => e.Id == id) > 0;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    db.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~TestCategoryRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
