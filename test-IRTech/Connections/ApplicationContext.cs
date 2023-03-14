using Microsoft.EntityFrameworkCore;
using test_IRTech.Models;

namespace test_IRTech.Connections
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Test> Tests { get; set; } = null!;
        public DbSet<Answer> Answers { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Answer>()
                   .HasOne(m => m.Test)
                   .WithMany(t => t.Answers)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Answer>()
                   .HasOne(m => m.Question)
                   .WithMany(t => t.Answers)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
