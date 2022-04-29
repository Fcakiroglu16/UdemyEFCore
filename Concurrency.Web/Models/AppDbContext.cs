using Microsoft.EntityFrameworkCore;

namespace Concurrency.Web.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Fluent API
            modelBuilder.Entity<Product>().Property(x => x.RowVersion).IsRowVersion();
            modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(18, 2);






            base.OnModelCreating(modelBuilder);
        }

    }
}
