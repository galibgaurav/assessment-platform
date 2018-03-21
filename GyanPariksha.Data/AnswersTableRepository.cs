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
    public class AnswersTableRepository : IDisposable, IAnswersTableRepository
    {
        public GyanParikshaDBContext db;
        public AnswersTableRepository(GyanParikshaDBContext _db)
        {
            db = _db;
        }
       public IEnumerable<Answers> Getanswers()
        {
            return db.answers;
        }

        public async Task<Answers> GetAnswers(Guid id)
        {
            var answers = await db.answers.FindAsync(id);
            return answers;
        }

        public async Task<Answers> PutAnswers(Guid id, Answers answers)
        {
            
            db.Entry(answers).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                    throw;
            }

            return answers;
        }

        public async Task<Answers> PostAnswers(Answers answers)
        {
            db.answers.Add(answers);
            await db.SaveChangesAsync();

            return answers;
        }

        public async Task<bool> DeleteAnswers(Guid id)
        {
            Answers answers = await db.answers.FindAsync(id);
            try {
                db.answers.Remove(answers);
                await db.SaveChangesAsync();
                return true;
            }
            catch (SqlException ex) {
                throw ex;
            }
         }
        
        public bool AnswersExists(Guid id)
        {
            return db.answers.Count(e => e.Id == id) > 0;
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
        // ~AnswersTableRepository() {
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
