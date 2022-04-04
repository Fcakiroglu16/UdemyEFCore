// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();
using (var _context = new AppDbContext())
{




    var leftJoinResult = await (from p in _context.Products
                                join pf in _context.productFeatures on p.Id equals pf.Id into pflist
                                from pf in pflist.DefaultIfEmpty()
                                select new
                                {
                                    ProductName = p.Name,
                                    ProductColor = pf.Color,
                                    ProductWidth = (int?)pf.Width == null ? 5 : pf.Width


                                }).ToListAsync();



    var rightJoinResult = await (from pf in _context.productFeatures
                                 join p in _context.Products on pf.Id equals p.Id into plist
                                 from p in plist.DefaultIfEmpty()
                                 select new
                                 {
                                     ProductName = p.Name,
                                     ProductPrice = (decimal?)p.Price,
                                     ProductColor = pf.Color,
                                     ProductWidth = pf.Width


                                 }).ToListAsync();






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

