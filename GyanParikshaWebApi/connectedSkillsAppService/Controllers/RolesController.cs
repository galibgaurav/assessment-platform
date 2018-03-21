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
    public class RolesController : ApiController
    {
        private GyanParikshaDBContext db = new GyanParikshaDBContext();

        // GET: api/Roles
        public IQueryable<Role> Getrole()
        {
            return db.role;
        }

        // GET: api/Roles/5
        [ResponseType(typeof(Role))]
        public async Task<IHttpActionResult> GetRole(Guid id)
        {
            Role role = await db.role.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // PUT: api/Roles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRole(Guid id, Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != role.Id)
            {
                return BadRequest();
            }

            db.Entry(role).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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

        // POST: api/Roles
        [ResponseType(typeof(Role))]
        public async Task<IHttpActionResult> PostRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.role.Add(role);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = role.Id }, role);
        }

        // DELETE: api/Roles/5
        [ResponseType(typeof(Role))]
        public async Task<IHttpActionResult> DeleteRole(Guid id)
        {
            Role role = await db.role.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            db.role.Remove(role);
            await db.SaveChangesAsync();

            return Ok(role);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoleExists(Guid id)
        {
            return db.role.Count(e => e.Id == id) > 0;
        }
    }
}