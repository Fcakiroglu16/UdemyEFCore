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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        public override int SaveChanges()
        {
            ChangeTracker.Entries().ToList().ForEach(e =>
             {
                 if (e.Entity is Product p)
                 {
                     if (e.State == EntityState.Added)
                     {
                         p.CreatedDate = DateTime.Now;
                     }
                 }
             });

            return base.SaveChanges();
        }
    }
}