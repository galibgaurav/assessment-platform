using GyanPariksha.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GyanPriksha.BL;
using Newtonsoft.Json;

namespace GyanPariksha.Data
{

    public class QuestionPaperRepository : IDisposable, IQuestionPaperRepository
    {
        private GyanParikshaDBContext db;
        private IQuestionPaperBL questionPaperBL;
      
        public QuestionPaperRepository(GyanParikshaDBContext _db,IQuestionPaperBL _questionPaperBL,ITestSubjectsRepository _testSubjectsRepository)
        {
            db = _db;
            questionPaperBL = _questionPaperBL;
        }

        public IEnumerable<QuestionPaper> GetquestionPaper()
        {
            return db.questionPaper;
        }

        public async Task<QuestionPaper> GetQuestionPaper(Guid id)
        {
            QuestionPaper questionPaper = await db.questionPaper.FindAsync(id);
            return questionPaper;
        }

        public async Task<QuestionPaper> PutQuestionPaper(Guid id, QuestionPaper questionPaper)
        {
            db.Entry(questionPaper).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            return questionPaper;
        }

        public async Task<QuestionPaper> PostQuestionPaper(QuestionPaper questionPaper)
        {
            try { 
            string refPath = questionPaper.TestId;  
            //var hb=JsonConvert.DeserializeObject<>
            questionPaperBL.WriteQuestionPaper(questionPaper.QuestionList,questionPaper.TestId);
            //TODO: Use mapper to map controller object to model
            questionPaper.QuestionList = null;
            db.questionPaper.Add(questionPaper);
            await db.SaveChangesAsync();
            return questionPaper;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteQuestionPaper(Guid id)
        {
            QuestionPaper questionPaper = await db.questionPaper.FindAsync(id);
            try
            {
                db.questionPaper.Remove(questionPaper);
                await db.SaveChangesAsync();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool QuestionPaperExists(Guid id)
        {
            return db.questionPaper.Count(e => e.Id == id) > 0;
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

    } }