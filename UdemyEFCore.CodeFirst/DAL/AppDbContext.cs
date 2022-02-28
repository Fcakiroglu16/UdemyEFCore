using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one-to-many
            // modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.Category_Id);

            //one-to-one
            //modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.ProductRef_Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}