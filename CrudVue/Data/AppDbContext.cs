using Microsoft.EntityFrameworkCore;
using CrudVue.Models;
namespace CrudVue.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>( p =>
            {
                p.HasKey("IdProduct");
                p.Property("IdProduct").ValueGeneratedOnAdd();
            });
        }
    }
}
