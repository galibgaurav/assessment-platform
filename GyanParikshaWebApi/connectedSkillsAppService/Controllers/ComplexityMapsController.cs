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
    public class ComplexityMapsController : ApiController
    {
        private GyanParikshaDBContext db = new GyanParikshaDBContext();

        // GET: api/ComplexityMaps
        public IQueryable<ComplexityMap> GetcomplexityMap()
        {
            return db.complexityMap;
        }

        // GET: api/ComplexityMaps/5
        [ResponseType(typeof(ComplexityMap))]
        public async Task<IHttpActionResult> GetComplexityMap(Guid id)
        {
            ComplexityMap complexityMap = await db.complexityMap.FindAsync(id);
            if (complexityMap == null)
            {
                return NotFound();
            }

            return Ok(complexityMap);
        }

        // PUT: api/ComplexityMaps/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutComplexityMap(Guid id, ComplexityMap complexityMap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != complexityMap.Id)
            {
                return BadRequest();
            }

            db.Entry(complexityMap).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComplexityMapExists(id))
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

        // POST: api/ComplexityMaps
        [ResponseType(typeof(ComplexityMap))]
        public async Task<IHttpActionResult> PostComplexityMap(ComplexityMap complexityMap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.complexityMap.Add(complexityMap);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = complexityMap.Id }, complexityMap);
        }

        // DELETE: api/ComplexityMaps/5
        [ResponseType(typeof(ComplexityMap))]
        public async Task<IHttpActionResult> DeleteComplexityMap(Guid id)
        {
            ComplexityMap complexityMap = await db.complexityMap.FindAsync(id);
            if (complexityMap == null)
            {
                return NotFound();
            }

            db.complexityMap.Remove(complexityMap);
            await db.SaveChangesAsync();

            return Ok(complexityMap);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComplexityMapExists(Guid id)
        {
            return db.complexityMap.Count(e => e.Id == id) > 0;
        }
    }
}