// See https://aka.ms/new-console-template for more information

using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();
using (var _context = new AppDbContext())
{



    var category = new Category() { Name = "Kalemler" };
    category.Products.Add(new() { Name = "kalem 1", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    category.Products.Add(new() { Name = "kalem 2", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    category.Products.Add(new() { Name = "kalem 3", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    category.Products.Add(new() { Name = "kalem 4", Price = 100, Stock = 200, Barcode = 123 });
    _context.Categories.Add(category);
    _context.SaveChanges();
    Console.WriteLine("işlem bitti");
}

