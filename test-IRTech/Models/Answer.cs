namespace test_IRTech.Models
{
    /// <summary>Class Model Answer</summary>
    public class Answer
    {
        /// <summary>Field Including Answer ID</summary>
        public Guid Id { get; set; }
        /// <summary>Field Including User Name</summary>
        public string? UserName { get; set; }
        /// <summary>Field Including Answer</summary>
        public int Responce { get; set; }
        public Test Test { get; set; }
        public Question Question { get; set; }
    }
}
