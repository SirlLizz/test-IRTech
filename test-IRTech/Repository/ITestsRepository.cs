using Microsoft.AspNetCore.Mvc;
using test_IRTech.Models;

namespace test_IRTech.Repository
{
    public interface ITestsRepository
    {
        IEnumerable<Test> Get();
        Test Get(Guid id);
        Guid Create(Test test);
        Guid Update(Guid id, Test test);
        Guid Delete(Guid id);
        IEnumerable<string> GetAllName();
    }
}
