using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using UdemyEFCore.CodeFirst.Models;

namespace UdemyEFCore.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {

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

            base.OnModelCreating(modelBuilder);
        }
    }
}