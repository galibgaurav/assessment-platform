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
    public class TestTakensRepository : IDisposable, ITestTakensRepository
    {
        private GyanParikshaDBContext db;
        public TestTakensRepository(GyanParikshaDBContext _db)
        {
            db = _db;
        }
        public IEnumerable<TestTaken> GettestTaken()
        {
            return db.testTaken;
        }

        public async Task<TestTaken> GetTestTaken(Guid id)
        {
            TestTaken testTaken = await db.testTaken.FindAsync(id);
            return testTaken;
        }

       public async Task<TestTaken> PutTestTaken(Guid id, TestTaken testTaken)
        {
           
            db.Entry(testTaken).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                    throw;
            }

            return testTaken;
        }

        public async Task<TestTaken> PostTestTaken(TestTaken testTaken)
        {
            db.testTaken.Add(testTaken);
            await db.SaveChangesAsync();
            return testTaken;
        }

        public async Task<bool> DeleteTestTaken(Guid id)
        {
            TestTaken testTaken = await db.testTaken.FindAsync(id);
            try
            {
                db.testTaken.Remove(testTaken);
                await db.SaveChangesAsync();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool TestTakenExists(Guid id)
        {
            return db.testTaken.Count(e => e.Id == id) > 0;
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
        // ~TestTakensRepository() {
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
