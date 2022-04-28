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


        public DbSet<ProductFull> productFulls { get; set; }

        public DbSet<ProductCount> ProductCount { get; set; }


        //public DbSet<Person> People { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }

        public IQueryable<ProductWithFeature> GetProductWithFeatures(int categoryId) => FromExpression(() => GetProductWithFeatures(categoryId));

        public int GetProductCount(int categoryId)
        {
            throw new NotSupportedException("Bu method ef core tarafından çalıştırılmaktadır.");
        }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductFull>().ToFunction("fc_product_full");


            modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(GetProductWithFeatures), new[] { typeof(int) })!).HasName("fc_product_full_with_parameters");


            modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(GetProductCount), new[] { typeof(int) })!).HasName("fc_get_product_count");

            modelBuilder.Entity<ProductCount>().HasNoKey();


            base.OnModelCreating(modelBuilder);
        }
    }
}