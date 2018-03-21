using GyanPariksha.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyanPariksha.Data
{
    public class TestsRepository : IDisposable, ITestsRepository
    {
        private GyanParikshaDBContext dBContext;
        public TestsRepository(GyanParikshaDBContext _dBContext)
        {
            dBContext = _dBContext;
        }
        public IEnumerable<Test> Gettest()
        {
            return dBContext.test;
        }
        public async Task<Test> GetTest(Guid id)
        {
            var test = await dBContext.test.FindAsync(id);
            return test;
        }
        public async Task<Test> PutTest(Guid id, Test test)
        {
            dBContext.Entry(test).State = EntityState.Modified;

            try
            {
                await dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                  throw;
            }

            return test;
        }

        public async Task<Test> PostTest(Test test)
        {
            dBContext.test.Add(test);
            await dBContext.SaveChangesAsync();
            return test;
        }

        public async Task<bool> DeleteTest(Guid id)
        {
            Test test = await dBContext.test.FindAsync(id);
            try {
                dBContext.test.Remove(test);
                await dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
        public bool TestExists(Guid id)
        {
            return dBContext.test.Count(e => e.Id == id) > 0;
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
                    dBContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~TestsRepository() {
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

