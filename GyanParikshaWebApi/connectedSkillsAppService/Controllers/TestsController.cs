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
    public class TestsController : ApiController
    {
        public ITestsRepository testsRepository;
        public TestsController(ITestsRepository _testsRepository)
        {
            testsRepository = _testsRepository;
        }

        
        // GET: api/Tests
        public IEnumerable<Test> Gettest()
        {
            return testsRepository.Gettest(); ;
        }

        // GET: api/Tests/5
        [ResponseType(typeof(Test))]
        public async Task<IHttpActionResult> GetTest(Guid id)
        {
            Test test = await testsRepository.GetTest(id);
            if (test == null)
            {
                return NotFound();
            }

            return Ok(test);
        }

        // PUT: api/Tests/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTest(Guid id, Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != test.Id)
            {
                return BadRequest();
            }

            try
            {
                await testsRepository.PutTest(id,test);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!testsRepository.TestExists(id))
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

        // POST: api/Tests
        [ResponseType(typeof(Test))]
        public async Task<IHttpActionResult> PostTest(Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            test = await testsRepository.PostTest(test);

            return CreatedAtRoute("DefaultApi", new { id = test.Id }, test);
        }

        // DELETE: api/Tests/5
        [ResponseType(typeof(Test))]
        public async Task<IHttpActionResult> DeleteTest(Guid id)
        {
            Test test = await testsRepository.GetTest(id);
            if (test == null)
            {
                return NotFound();
            }

            await testsRepository.DeleteTest(id);
            return Ok(test);
        }
    }
}