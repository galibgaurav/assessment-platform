using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GyanPariksha.Model;
using System.Data.Entity;
using System.Data.SqlClient;

namespace GyanPariksha.Data
{
   public class ContactUsRepository : IDisposable, IContactUsRepository
    {
        private GyanParikshaDBContext dBContext;
        public ContactUsRepository(GyanParikshaDBContext _dBContext)
        {
            dBContext = _dBContext;
        }

        public IEnumerable<ContactUs> GetContactUs()
        {
            return dBContext.contactUs;
        }

        public async Task<ContactUs> GetContactUs(Guid id)
        {
            var contactUs = await dBContext.contactUs.FindAsync(id);
            return contactUs;          
        }

        public async Task<ContactUs> PutContactUs(Guid id, ContactUs contactUs)
        {
            dBContext.Entry(contactUs).State = EntityState.Modified;

            try
            {
                await dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                    throw;
            }

            return contactUs;
        }
        public async Task<ContactUs> PostContactUs(ContactUs contactUs)
        {
            dBContext.contactUs.Add(contactUs);
            await dBContext.SaveChangesAsync();

            return contactUs;
        }


        public async Task<bool> DeleteContactUs(Guid id)
        {
            ContactUs contactUs = await dBContext.contactUs.FindAsync(id);
            try { 
            dBContext.contactUs.Remove(contactUs);
            await dBContext.SaveChangesAsync();
            return true;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
          
        }

        public bool ContactUsExists(Guid id)
        {
            return dBContext.contactUs.Count(e => e.Id == id) > 0;
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
        // ~ContactUsRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
