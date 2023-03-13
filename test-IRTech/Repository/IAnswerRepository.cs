using test_IRTech.Models;

namespace test_IRTech.Repository
{
    public interface IAnswerRepository
    {
        Dictionary<string, int> GetStatsToTest(Guid testId);
        Dictionary<string, int> GetStatsToTests();
        int CountUserAnswer(Guid testId);
        Guid Create(Answer answer);
        void Delete();
    }
}
