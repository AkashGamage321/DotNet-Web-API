using Microsoft.EntityFrameworkCore;
using Supermarket.Models;

namespace Supermarket.Data
{

    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        
        public DbSet<Items>Item { get; set; } 
        public DbSet<Cart_info> Cart { get; set; }
    }
}