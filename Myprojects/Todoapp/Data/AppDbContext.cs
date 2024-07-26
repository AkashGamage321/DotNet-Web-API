using Microsoft.EntityFrameworkCore;
using Todoapp.Models;

namespace Todoapp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskModel> TaskModels { get; set; }
    }
}
