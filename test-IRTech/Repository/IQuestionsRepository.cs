using Microsoft.AspNetCore.Mvc;
using test_IRTech.Models;

namespace test_IRTech.Repository
{
    public interface IQuestionsRepository
    {
        IEnumerable<Question> GetToTest(Guid testId);
        Question Get(Guid id);
        Guid Create(Question question);
        Guid Update(Guid id, Question question);
        Guid Delete(Guid id);
    }
}
