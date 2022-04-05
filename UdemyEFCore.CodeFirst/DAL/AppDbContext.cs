using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UdemyEFCore.CodeFirst.Models;

namespace UdemyEFCore.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {



        private readonly int Barcode;

        public AppDbContext(int barcode)
        {
            Barcode = barcode;
        }

        public AppDbContext()
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> productFeatures { get; set; }






        //public DbSet<Person> People { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.IsDeleted).HasDefaultValue(false);

            if (Barcode != default(int))
            {
                modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted && p.Barcode == Barcode);
            }
            else
            {
                modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
            }



            base.OnModelCreating(modelBuilder);
        }
    }
}