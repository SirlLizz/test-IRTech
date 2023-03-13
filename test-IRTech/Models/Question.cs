namespace test_IRTech.Models
{
    /// <summary>Class Model Question</summary>
    public class Question
    {
        /// <summary>Field Including Question ID</summary>
        public Guid Id { get; set; }
        /// <summary>Field Including Description of Question</summary>
        public string? Description { get; set; }
        /// <summary>Field Including Responce Scale n to Answer</summary>
        public int ResponceScale { get; set; }
        public Test? Test { get; set; }

    }
}
