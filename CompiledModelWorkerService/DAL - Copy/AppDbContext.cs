using Microsoft.EntityFrameworkCore;


namespace UdemyEFCore.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {

       

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> productFeatures { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



    }
}