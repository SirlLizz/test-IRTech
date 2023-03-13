using Microsoft.AspNetCore.Mvc;
using test_IRTech.Exceptions;
using test_IRTech.Models;
using test_IRTech.Repository;

namespace test_IRTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswersRepository _repository;

        public AnswersController(IAnswersRepository repository)
        {
            _repository = repository;
        }

        /// <summary>Get Stats To Test</summary>
        /// <returns>Stats</returns>
        [HttpGet("stats-test/{testId}")]
        public ActionResult<Dictionary<string, double>> GetStatsToTest(Guid testId)
        {
            try
            {
                return _repository.GetStatsToTest(testId);
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

        /// <summary>Get Stats To Tests</summary>
        /// <returns>Stats</returns>
        [HttpGet("stats-tests")]
        public ActionResult<Dictionary<string, int>> GetStatsToTests()
        {
            try
            {
                return _repository.GetStatsToTests();
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>Get Count User Answer</summary>
        /// <returns>Count</returns>
        [HttpGet("{testId}")]
        public ActionResult<int> CountUserAnswer(Guid testId)
        {
            try
            {
                return _repository.CountUserAnswer(testId);
            }
            catch
            {
                return Problem();
            }

        }

        /// <summary>Add Answers To DataBase</summary>
        /// <returns>Post</returns>
        [HttpPost]
        public ActionResult Post([FromBody] IEnumerable<Answer> answers)
        {
            try
            {
                _repository.Create(answers);
                return Ok();
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

        /// <summary>Delete All Answers</summary>
        /// <returns>Post</returns>
        [HttpDelete]
        public ActionResult Delete()
        {
            try
            {
                _repository.Delete();
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }
    }
}
