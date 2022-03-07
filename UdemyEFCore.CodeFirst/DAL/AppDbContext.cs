using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UdemyEFCore.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; private set; }
        public DbSet<Category> Categories { get; private set; }

        public DbSet<ProductFeature> productFeatures { get; private set; }

        //public DbSet<Student> Students { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).UseLazyLoadingProxies().UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}