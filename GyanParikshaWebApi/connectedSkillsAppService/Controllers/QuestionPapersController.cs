using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GyanPariksha.Data;
using GyanPariksha.Model;

namespace GyanParikshaWebApi.Controllers
{
    public class QuestionPapersController : ApiController
    {
        private IQuestionPaperRepository questionPaperRepository;
       public QuestionPapersController(IQuestionPaperRepository _questionPaperRepository)
        {
            questionPaperRepository = _questionPaperRepository;
        }

        // GET: api/QuestionPapers
        public IEnumerable<QuestionPaper> GetquestionPaper()
        {
            return questionPaperRepository.GetquestionPaper();
        }

        // GET: api/QuestionPapers/5
        [ResponseType(typeof(QuestionPaper))]
        public async Task<IHttpActionResult> GetQuestionPaper(Guid id)
        {
            QuestionPaper questionPaper = await questionPaperRepository.GetQuestionPaper(id);
            if (questionPaper == null)
            {
                return NotFound();
            }

            return Ok(questionPaper);
        }

        // PUT: api/QuestionPapers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQuestionPaper(Guid id, QuestionPaper questionPaper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionPaper.Id)
            {
                return BadRequest();
            }

            try
            {
                await questionPaperRepository.PutQuestionPaper(id,questionPaper);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!questionPaperRepository.QuestionPaperExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/QuestionPapers
        [ResponseType(typeof(QuestionPaper))]
        public async Task<IHttpActionResult> PostQuestionPaper(QuestionPaper questionPaper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            questionPaper = await questionPaperRepository.PostQuestionPaper(questionPaper);
            return CreatedAtRoute("DefaultApi", new { id = questionPaper.Id }, questionPaper);
        }

        // DELETE: api/QuestionPapers/5
        [ResponseType(typeof(QuestionPaper))]
        public async Task<IHttpActionResult> DeleteQuestionPaper(Guid id)
        {
            QuestionPaper questionPaper = await questionPaperRepository.GetQuestionPaper(id);
            if (questionPaper == null)
            {
                return NotFound();
            }

            await questionPaperRepository.DeleteQuestionPaper(id);
            return Ok(questionPaper);
        }
        
    }
}