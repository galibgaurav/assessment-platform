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
    public class TestCategoriesController : ApiController
    {
        public ITestCategoryRepository testCategoryRepository;
        public TestCategoriesController(ITestCategoryRepository _testCategoryRepository)
        {
            testCategoryRepository = _testCategoryRepository;
        }

        // GET: api/TestCategories
        public IEnumerable<TestCategory> GettestCategory()
        {
            return testCategoryRepository.GetTestCategory();
        }

        // GET: api/TestCategories/5
        [ResponseType(typeof(TestCategory))]
        public async Task<IHttpActionResult> GetTestCategory(Guid id)
        {
            TestCategory testCategory = await testCategoryRepository.GetTestCategory(id);
            if (testCategory == null)
            {
                return NotFound();
            }

            return Ok(testCategory);
        }

        // PUT: api/TestCategories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTestCategory(Guid id, TestCategory testCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testCategory.Id)
            {
                return BadRequest();
            }

            try
            {
                await testCategoryRepository.PutTestCategory(id,testCategory);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!testCategoryRepository.TestCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TestCategories
        [ResponseType(typeof(TestCategory))]
        public async Task<IHttpActionResult> PostTestCategory(TestCategory testCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            testCategory =await testCategoryRepository.PostTestCategory(testCategory);           
            return CreatedAtRoute("DefaultApi", new { id = testCategory.Id }, testCategory);
        }

        // DELETE: api/TestCategories/5
        [ResponseType(typeof(TestCategory))]
        public async Task<IHttpActionResult> DeleteTestCategory(Guid id)
        {
            TestCategory testCategory = await testCategoryRepository.GetTestCategory(id);
            if (testCategory == null)
            {
                return NotFound();
            }

            await testCategoryRepository.DeleteTestCategory(id);
            return Ok(testCategory);
        }
        
    }
}