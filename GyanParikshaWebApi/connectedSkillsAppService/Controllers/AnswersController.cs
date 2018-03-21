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
    public class AnswersController : ApiController
    {
        private GyanParikshaDBContext db = new GyanParikshaDBContext();

        // GET: api/Answers
        public IQueryable<Answers> Getanswers()
        {
            return db.answers;
        }

        // GET: api/Answers/5
        [ResponseType(typeof(Answers))]
        public async Task<IHttpActionResult> GetAnswers(Guid id)
        {
            Answers answers = await db.answers.FindAsync(id);
            if (answers == null)
            {
                return NotFound();
            }

            return Ok(answers);
        }

        // PUT: api/Answers/5
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

            db.Entry(answers).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Answers
        [ResponseType(typeof(Answers))]
        public async Task<IHttpActionResult> PostAnswers(Answers answers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.answers.Add(answers);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = answers.Id }, answers);
        }

        // DELETE: api/Answers/5
        [ResponseType(typeof(Answers))]
        public async Task<IHttpActionResult> DeleteAnswers(Guid id)
        {
            Answers answers = await db.answers.FindAsync(id);
            if (answers == null)
            {
                return NotFound();
            }

            db.answers.Remove(answers);
            await db.SaveChangesAsync();

            return Ok(answers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnswersExists(Guid id)
        {
            return db.answers.Count(e => e.Id == id) > 0;
        }
    }
}