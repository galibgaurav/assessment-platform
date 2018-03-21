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
    public class ComplexityLevelsController : ApiController
    {
        private GyanParikshaDBContext db = new GyanParikshaDBContext();

        // GET: api/ComplexityLevels
        public IQueryable<ComplexityLevel> GetcomplexityLevel()
        {
            return db.complexityLevel;
        }

        // GET: api/ComplexityLevels/5
        [ResponseType(typeof(ComplexityLevel))]
        public async Task<IHttpActionResult> GetComplexityLevel(Guid id)
        {
            ComplexityLevel complexityLevel = await db.complexityLevel.FindAsync(id);
            if (complexityLevel == null)
            {
                return NotFound();
            }

            return Ok(complexityLevel);
        }

        // PUT: api/ComplexityLevels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutComplexityLevel(Guid id, ComplexityLevel complexityLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != complexityLevel.Id)
            {
                return BadRequest();
            }

            db.Entry(complexityLevel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComplexityLevelExists(id))
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

        // POST: api/ComplexityLevels
        [ResponseType(typeof(ComplexityLevel))]
        public async Task<IHttpActionResult> PostComplexityLevel(ComplexityLevel complexityLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.complexityLevel.Add(complexityLevel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = complexityLevel.Id }, complexityLevel);
        }

        // DELETE: api/ComplexityLevels/5
        [ResponseType(typeof(ComplexityLevel))]
        public async Task<IHttpActionResult> DeleteComplexityLevel(Guid id)
        {
            ComplexityLevel complexityLevel = await db.complexityLevel.FindAsync(id);
            if (complexityLevel == null)
            {
                return NotFound();
            }

            db.complexityLevel.Remove(complexityLevel);
            await db.SaveChangesAsync();

            return Ok(complexityLevel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComplexityLevelExists(Guid id)
        {
            return db.complexityLevel.Count(e => e.Id == id) > 0;
        }
    }
}