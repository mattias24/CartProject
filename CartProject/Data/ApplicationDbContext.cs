using CartProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CartProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Category { get; set; }
   

    }
}
