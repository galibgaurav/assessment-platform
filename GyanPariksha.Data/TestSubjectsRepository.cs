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
    public class TestSubjectsRepository : IDisposable, ITestSubjectsRepository
    {
        private GyanParikshaDBContext db;// = new GyanParikshaDBContext();
        public TestSubjectsRepository(GyanParikshaDBContext _db)
        {
            db = _db;
        }
        // GET: api/TestSubjects
        public IEnumerable<TestSubject> GetTestSubject()
        {
            return db.testSubject;
        }

        public async Task<TestSubject> GetTestSubject(Guid id)
        {
            var testSubject = await db.testSubject.FindAsync(id);
            return testSubject;
        }

        public async Task<TestSubject> PutTestSubject(Guid id, TestSubject testSubject)
        {
            db.Entry(testSubject).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return testSubject;
        }

        public async Task<TestSubject> PostTestSubject(TestSubject testSubject)
        {
            db.testSubject.Add(testSubject);
            await db.SaveChangesAsync();
            return testSubject;
        }

        public async Task<bool> DeleteTestSubject(Guid id)
        {
            TestSubject testSubject = await db.testSubject.FindAsync(id);
            try {
                db.testSubject.Remove(testSubject);
                await db.SaveChangesAsync();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            
        }
        public bool TestSubjectExists(Guid id)
        {
            return db.testSubject.Count(e => e.Id == id) > 0;
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
        // ~TestSubjectsRepository() {
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
