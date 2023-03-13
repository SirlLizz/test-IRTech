using test_IRTech.Models;

namespace test_IRTech.Repository
{
    public interface IAnswersRepository
    {
        Dictionary<string, double> GetStatsToTest(Guid testId);
        Dictionary<string, int> GetStatsToTests();
        int CountUserAnswer(Guid testId);
        void Create(IEnumerable<Answer> answer);
        void Delete();
    }
}
