using test_IRTech.Connections;
using test_IRTech.Models;
using test_IRTech.Exceptions;

namespace test_IRTech.Repository
{
    public class TestsRepository : ITestsRepository
    {
        private readonly ApplicationContext _context;

        public TestsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Test> Get()
        {
            return _context.Tests;
        }

        public Test Get(Guid id)
        {
            Test test = _context.Tests.Find(id);
            return test ?? throw new NotFoundInDatabaseException();
        }

        public Guid Create(Test test)
        {
            _context.Tests.Add(test);
            _context.SaveChanges();
            return test.Id;
        }

        public Guid Delete(Guid id)
        {
            Test test = Get(id) ?? throw new NotFoundInDatabaseException();
            _context.Tests.Remove(test);
            _context.SaveChanges();
            return test.Id;
        }

        public Guid Update(Guid id, Test newTest)
        {
            Test currentTest = Get(id) ?? throw new NotFoundInDatabaseException();
            currentTest.Name = newTest.Name;
            currentTest.Questions = newTest.Questions;
            _context.Tests.Update(currentTest);
            _context.SaveChanges();
            return currentTest.Id;
        }

        public IEnumerable<string> GetAllName()
        {
            return _context.Tests.Select(t => t.Name);
        }
    }
}
