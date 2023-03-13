using Microsoft.EntityFrameworkCore;
using test_IRTech.Models;

namespace test_IRTech.Connections
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Test> Tests { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=HOME-PC;Initial Catalog=test-IRTech;Integrated Security=True;TrustServerCertificate=true;");
        }
    }
}
