using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using test_IRTech.Exceptions;
using test_IRTech.Models;
using test_IRTech.Repository;

namespace test_IRTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Tests")]
    public class TestsController : ControllerBase
    {
        private readonly ITestsRepository _repository;

        public TestsController(ITestsRepository repository)
        {
            _repository = repository;
        }

        /// <summary>Get All Tests</summary>
        /// <returns>All Tests</returns>
        [HttpGet]
        public ActionResult<IList<Test>> Get()
        {
            try
            {
                return _repository.Get().ToList();
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>Get All Test Name</summary>
        /// <returns>All Test Name</returns>
        [HttpGet("name")]
        public ActionResult<IList<string>> GetAllName()
        {
            try
            {
                return _repository.GetAllName().ToList();
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>Get Test By ID</summary>
        /// <returns>Test</returns>
        [HttpGet("{id}")]
        public ActionResult<Test> Get(Guid id)
        {
            try
            {
                return _repository.Get(id);
            }
            catch (NotFoundInDatabaseException)
            {
                return NotFound();
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>Add Test To DataBase</summary>
        /// <returns>Test</returns>
        [HttpPost]
        public ActionResult<Guid> Post([FromBody] Test Test)
        {
            try
            {
                return _repository.Create(Test);
            }
            catch
            {
                return Problem();
            }

        }

        /// <summary>Change Test In DataBase</summary>
        /// <returns>Test ID</returns>
        [HttpPut("{id}")]
        public ActionResult<Guid> Put(Guid id, [FromBody] Test Test)
        {
            try
            {
                return _repository.Update(id, Test);
            }
            catch (NotFoundInDatabaseException)
            {
                return NotFound();
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>Delete Test From DataBase</summary>
        /// <returns>Test ID</returns>
        [HttpDelete("{id}")]
        public ActionResult<Guid> Delete(Guid id)
        {
            try
            {
                return _repository.Delete(id);
            }
            catch (NotFoundInDatabaseException)
            {
                return NotFound();
            }
            catch
            {
                return Problem();
            }
        }
    }
}

