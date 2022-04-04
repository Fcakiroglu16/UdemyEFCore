// See https://aka.ms/new-console-template for more information

using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();
using (var _context = new AppDbContext())
{
    //2'li join
    // var result = _context.Categories.Join(_context.Products, x => x.Id, y => y.CategoryId, (c, p) => p).ToList();

    //2'li join
    //var result2 = (from c in _context.Categories
    //               join p in _context.Products on c.Id equals p.CategoryId
    //               select new
    //               {
    //                   CategoryName = c.Name,
    //                   Productname = p.Name,
    //                   ProductPrice = p.Price

    //               }).ToList();





    //3'lü join
    var result = _context.Categories
        .Join(_context.Products, c => c.Id, p => p.CategoryId, (c, p) => new { c, p })
        .Join(_context.productFeatures, x => x.p.Id, y => y.Id, (c, pf) => new
        {
            CategoryName = c.c.Name,
            ProductName = c.p.Name,
            ProductFeatureColor = pf.Color

        });

    Console.WriteLine("");

    //3'lü join
    var result2 = (from c in _context.Categories
                   join p in _context.Products on c.Id equals p.CategoryId
                   join pf in _context.productFeatures on p.Id equals pf.Id
                   select new { c, p, pf }).ToList();






    Console.WriteLine("");














    //var category = new Category() { Name = "Kalemler" };
    //category.Products.Add(new() { Name = "kalem 1", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "kalem 2", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "kalem 3", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "kalem 4", Price = 100, Stock = 200, Barcode = 123 });
    //_context.Categories.Add(category);
    //_context.SaveChanges();
    Console.WriteLine("işlem bitti");
}

