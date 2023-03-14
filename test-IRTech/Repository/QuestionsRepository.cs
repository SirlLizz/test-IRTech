using test_IRTech.Connections;
using test_IRTech.Models;
using test_IRTech.Exceptions;

namespace test_IRTech.Repository
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly ApplicationContext _context;

        public QuestionsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Guid Create(Question question)
        {
            Test test = _context.Tests.Single(g => g.Id == question.Test.Id) ?? throw new NotFoundInDatabaseException();
            question.Test = test;
            _context.Questions.Add(question);
            _context.SaveChanges();
            return question.Id;
        }

        public Guid Delete(Guid id)
        {
            Question question = Get(id) ?? throw new NotFoundInDatabaseException();
            _context.Questions.Remove(question);
            _context.SaveChanges();
            return question.Id;
        }

        public Question Get(Guid id)
        {
            Question question = _context.Questions.Find(id);
            return question ?? throw new NotFoundInDatabaseException();
        }

        public IEnumerable<Question> GetToTest(Guid testId)
        {
            return _context.Questions.Where(x => x.Test.Id == testId);
        }

        public Guid Update(Guid id, Question newQuestion)
        {
            Question currentQuestion = Get(id) ?? throw new NotFoundInDatabaseException();
            currentQuestion.Description = newQuestion.Description;
            currentQuestion.Test = newQuestion.Test;
            currentQuestion.ResponceScale = newQuestion.ResponceScale;
            _context.Questions.Update(currentQuestion);
            _context.SaveChanges();
            return currentQuestion.Id;
        }

    }
}
