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
    public class ContactUsController : ApiController
    {
        private ContactUsRepository contactUsRepository;
        public ContactUsController(ContactUsRepository _contactUsRepository)
        {
            contactUsRepository = _contactUsRepository;
        }

        // GET: api/ContactUs
        public IEnumerable<ContactUs> GetcontactUs()
        {
            return contactUsRepository.GetContactUs();
        }

        // GET: api/ContactUs/5
        [ResponseType(typeof(ContactUs))]
        public async Task<IHttpActionResult> GetContactUs(Guid id)
        {
            ContactUs contactUs = await contactUsRepository.GetContactUs(id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return Ok(contactUs);
        }

        // PUT: api/ContactUs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContactUs(Guid id, ContactUs contactUs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactUs.Id)
            {
                return BadRequest();
            }

            try
            {
                await contactUsRepository.PutContactUs(id,contactUs);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! contactUsRepository.ContactUsExists(id))
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

        // POST: api/ContactUs
        [ResponseType(typeof(ContactUs))]
        //[HttpPost]
        public async Task<IHttpActionResult> PostContactUs(ContactUs contactUs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            contactUs = await contactUsRepository.PostContactUs(contactUs);

            return CreatedAtRoute("DefaultApi", new { id = contactUs.Id }, contactUs);
        }

        // DELETE: api/ContactUs/5
        [ResponseType(typeof(ContactUs))]
        public async Task<IHttpActionResult> DeleteContactUs(Guid id)
        {
            ContactUs contactUs = await contactUsRepository.GetContactUs(id);
            if (contactUs == null)
            {
                return NotFound();
            }

            await contactUsRepository.DeleteContactUs(id);

            return Ok(contactUs);
        }
        
    }
}