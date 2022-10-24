using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace UdemyEFCore.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<ProductFeature> productFeatures { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.SavingChanges += AppDbContext_SavingChanges;
        }

        private void AppDbContext_SavingChanges(object? sender, SavingChangesEventArgs e)
        {
            // 2. way

            foreach (var item in ChangeTracker.Entries())
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        {
                            item.Property("UpdatedDate").IsModified = false;
                            item.Property("CreatedDate").CurrentValue = DateTime.Now;
                            break;
                        }
                    case EntityState.Modified:
                        {
                            item.Property("CreatedDate").IsModified = false;
                            item.Property("UpdatedDate").CurrentValue = DateTime.Now;

                            break;
                        }
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(build =>
            {
                build.Property<DateTime?>("UpdatedDate");
                build.Property<DateTime>("CreatedDate");
            });

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // One way
            //foreach (var item in ChangeTracker.Entries())
            //{
            //    switch (item.State)
            //    {
            //        case EntityState.Added:
            //            {
            //                item.Property("UpdatedDate").IsModified = false;
            //                item.Property("CreatedDate").CurrentValue = DateTime.Now;
            //                break;
            //            }
            //        case EntityState.Modified:
            //            {
            //                item.Property("CreatedDate").IsModified = false;
            //                item.Property("UpdatedDate").CurrentValue = DateTime.Now;

            //                break;
            //            }
            //    }
            //}

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}