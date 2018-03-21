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
    public class TestSubjectsController : ApiController
    {
        public ITestSubjectsRepository testSubjectsRepository;
        public TestSubjectsController(ITestSubjectsRepository _testSubjectsRepository)
        {
            testSubjectsRepository = _testSubjectsRepository;
        }

        // GET: api/TestSubjects
        public IEnumerable<TestSubject> GettestSubject()
        {
            return testSubjectsRepository.GetTestSubject();
        }

        // GET: api/TestSubjects/5
        [ResponseType(typeof(TestSubject))]
        public async Task<IHttpActionResult> GetTestSubject(Guid id)
        {
            TestSubject testSubject = await testSubjectsRepository.GetTestSubject(id);
            if (testSubject == null)
            {
                return NotFound();
            }

            return Ok(testSubject);
        }

        // PUT: api/TestSubjects/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTestSubject(Guid id, TestSubject testSubject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testSubject.Id)
            {
                return BadRequest();
            }

            try
            {
                await testSubjectsRepository.PutTestSubject(id,testSubject);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!testSubjectsRepository.TestSubjectExists(id))
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

        // POST: api/TestSubjects
        [ResponseType(typeof(TestSubject))]
        public async Task<IHttpActionResult> PostTestSubject(TestSubject testSubject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            testSubject = await testSubjectsRepository.PostTestSubject(testSubject);

            return CreatedAtRoute("DefaultApi", new { id = testSubject.Id }, testSubject);
        }

        // DELETE: api/TestSubjects/5
        [ResponseType(typeof(TestSubject))]
        public async Task<IHttpActionResult> DeleteTestSubject(Guid id)
        {
            TestSubject testSubject = await testSubjectsRepository.GetTestSubject(id);
            if (testSubject == null)
            {
                return NotFound();
            }

            await testSubjectsRepository.DeleteTestSubject(id);
            return Ok(testSubject);
        }
    }
}