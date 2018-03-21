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
    public class TestTakensController : ApiController
    {
        public TestTakensRepository testTakensRepository;
        public TestTakensController(TestTakensRepository _testTakensRepository)
        {
            testTakensRepository = _testTakensRepository;
        }
        // GET: api/TestTakens
        public IEnumerable<TestTaken> GettestTaken()
        {
            return testTakensRepository.GettestTaken();
        }

        // GET: api/TestTakens/5
        [ResponseType(typeof(TestTaken))]
        public async Task<IHttpActionResult> GetTestTaken(Guid id)
        {
            TestTaken testTaken = await testTakensRepository.GetTestTaken(id);
            if (testTaken == null)
            {
                return NotFound();
            }

            return Ok(testTaken);
        }

        // PUT: api/TestTakens/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTestTaken(Guid id, TestTaken testTaken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testTaken.Id)
            {
                return BadRequest();
            }

            try
            {
                await testTakensRepository.PutTestTaken(id, testTaken);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!testTakensRepository.TestTakenExists(id))
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

        // POST: api/TestTakens
        [ResponseType(typeof(TestTaken))]
        public async Task<IHttpActionResult> PostTestTaken(TestTaken testTaken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            testTaken = await testTakensRepository.PostTestTaken(testTaken);

            return CreatedAtRoute("DefaultApi", new { id = testTaken.Id }, testTaken);
        }

        // DELETE: api/TestTakens/5
        [ResponseType(typeof(TestTaken))]
        public async Task<IHttpActionResult> DeleteTestTaken(Guid id)
        {
            TestTaken testTaken = await testTakensRepository.GetTestTaken(id);
            if (testTaken == null)
            {
                return NotFound();
            }

            await testTakensRepository.DeleteTestTaken(id);

            return Ok(testTaken);
        }       
    }
}