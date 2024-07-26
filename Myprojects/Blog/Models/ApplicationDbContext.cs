using Microsoft.EntityFrameworkCore;

namespace Blog.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<YourModel> YourModels { get; set; }
    }
}
