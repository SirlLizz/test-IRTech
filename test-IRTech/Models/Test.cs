using System.Text.RegularExpressions;

namespace test_IRTech.Models
{
    /// <summary>Class Model Test</summary>
    public class Test
    {
        /// <summary>Field Including Test ID</summary>
        public Guid Id { get; set; }
        /// <summary>Field Including Test Name</summary>
        public string? Name { get; set; }
        public IEnumerable<Question>? Questions { get; set; }
        public virtual IEnumerable<Answer>? Answers { get; set; }
    }
}
