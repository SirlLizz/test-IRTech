using Microsoft.EntityFrameworkCore;
using System.Numerics;
using test_IRTech.Connections;
using test_IRTech.Exceptions;
using test_IRTech.Models;

namespace test_IRTech.Repository
{
    public class AnswersRepository : IAnswersRepository
    {
        private readonly ApplicationContext _context;

        public AnswersRepository(ApplicationContext context)
        {
            _context = context;
        }
        public int CountUserAnswer(Guid testId)
        {
            return _context.Answers.Where(x => x.Test.Id == testId).GroupBy(g => g.UserName).Count();
        }

        public void Create(IEnumerable<Answer> answers)
        {
            foreach(Answer answer in answers)
            {
                Test test = _context.Tests.Single(g => g.Id == answer.Test.Id) ?? throw new NotFoundInDatabaseException();
                Question question = _context.Questions.Single(g => g.Id == answer.Question.Id) ?? throw new NotFoundInDatabaseException();
                answer.Question = question;
                answer.Test = test;
                _context.Answers.Add(answer);
            }
            _context.SaveChanges();
        }

        public void Delete()
        {
            _context.Database.ExecuteSql($"TRUNCATE TABLE Answers");
            //_context.Answers.RemoveRange(_context.Answers);//не самый лучший вариант, так как прогоняет все записи в одну и во вторую сторону, но иначе не придумал как truncate реализовать
        }

        public Dictionary<string, double> GetStatsToTest(Guid testId)
        {
            return _context.Answers.Where(x => x.Test.Id == testId).GroupBy(i => i.Question.Description).Select(g => new KeyValuePair<string, double>(g.Key, g.Average(x => x.Responce))).ToDictionary(x => x.Key, x => x.Value);
        }

        public Dictionary<string, int> GetStatsToTests()
        {
            return (Dictionary<string, int>)_context.Answers.GroupBy(i => i.Test.Name).Select(g => new KeyValuePair<string, int>(g.Key, g.Count())).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
