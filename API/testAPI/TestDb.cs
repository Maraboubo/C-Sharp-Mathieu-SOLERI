using Microsoft.EntityFrameworkCore;

namespace TestApi
{
    public class TestDb : DbContext
    {
        public TestDb(DbContextOptions<TestDb> options) : base(options) { }

        public DbSet<Test> Tests => Set<Test>();
    }
}
