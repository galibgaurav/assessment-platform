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
    public class AnswerTableController : ApiController
    {
        public IAnswersTableRepository answersTableRepository;
        public AnswerTableController(IAnswersTableRepository _answersTableRepository)
        {

        }
        // GET: api/AnswerTable
        public IEnumerable<Answers> Getanswers()
        {
            return answersTableRepository.Getanswers();
        }

        // GET: api/AnswerTable/5
        [ResponseType(typeof(Answers))]
        public async Task<IHttpActionResult> GetAnswers(Guid id)
        {
            Answers answers = await answersTableRepository.GetAnswers(id);
            if (answers == null)
            {
                return NotFound();
            }

            return Ok(answers);
        }

        // PUT: api/AnswerTable/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAnswers(Guid id, Answers answers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != answers.Id)
            {
                return BadRequest();
            }
            
            try
            {
                await answersTableRepository.PutAnswers(id,answers);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!answersTableRepository.AnswersExists(id))
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

        // POST: api/AnswerTable
        [ResponseType(typeof(Answers))]
        public async Task<IHttpActionResult> PostAnswers(Answers answers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            answers=await answersTableRepository.PostAnswers(answers);

            return CreatedAtRoute("DefaultApi", new { id = answers.Id }, answers);
        }

        // DELETE: api/AnswerTable/5
        [ResponseType(typeof(Answers))]
        public async Task<IHttpActionResult> DeleteAnswers(Guid id)
        {
            Answers answers = await answersTableRepository.GetAnswers(id);
            if (answers == null)
            {
                return NotFound();
            }

            await answersTableRepository.DeleteAnswers(id);

            return Ok(answers);
        }
}
}