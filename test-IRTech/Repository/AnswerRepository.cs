using test_IRTech.Connections;
using test_IRTech.Models;

namespace test_IRTech.Repository
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ApplicationContext _context;

        public AnswerRepository(ApplicationContext context)
        {
            _context = context;
        }
        public int CountUserAnswer(Guid testId)
        {
            throw new NotImplementedException();
        }

        public Guid Create(Answer answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();
            return answer.Id;
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, int> GetStatsToTest(Guid testId)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, int> GetStatsToTests()
        {
            throw new NotImplementedException();
        }
    }
}
