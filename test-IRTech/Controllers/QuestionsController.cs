using Microsoft.AspNetCore.Mvc;
using test_IRTech.Exceptions;
using test_IRTech.Models;
using test_IRTech.Repository;

namespace Question_IRTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsRepository _repository;

        public QuestionsController(IQuestionsRepository repository)
        {
            _repository = repository;
        }

        /// <summary>Get Question By ID</summary>
        /// <returns>Question</returns>
        [HttpGet("test/{testId}")]
        public ActionResult<IList<Question>> GetToTest(Guid testId)
        {
            try
            {
                return _repository.GetToTest(testId).ToList();
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

        /// <summary>Get Question By ID</summary>
        /// <returns>Question</returns>
        [HttpGet("{id}")]
        public ActionResult<Question> Get(Guid id)
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

        /// <summary>Add Question To DataBase</summary>
        /// <returns>Question</returns>
        [HttpPost]
        public ActionResult<Guid> Post([FromBody] Question Question)
        {
            try
            {
                return _repository.Create(Question);
            }
            catch
            {
                return Problem();
            }

        }

        /// <summary>Change Question In DataBase</summary>
        /// <returns>Question ID</returns>
        [HttpPut("{id}")]
        public ActionResult<Guid> Put(Guid id, [FromBody] Question Question)
        {
            try
            {
                return _repository.Update(id, Question);
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

        /// <summary>Delete Question From DataBase</summary>
        /// <returns>Question ID</returns>
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

