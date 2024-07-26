using Microsoft.EntityFrameworkCore;
using Webapi_basics.Models;

namespace Webapi_basics.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        :base(dbContextOptions)
        {
        }
        public DbSet<ToDoItem>todos { get; set; }

    }
}