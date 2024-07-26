using Microsoft.EntityFrameworkCore;
using Bookshop.Models;

namespace Bookshop.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
        }
        public DbSet<Books> Book { get; set; }
        public DbSet<BookInfo> Booksinfo { get; set; }
    }
}