// See https://aka.ms/new-console-template for more information

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;
using UdemyEFCore.CodeFirst.Models;

Initializer.Build();





using (var _context = new AppDbContext())
{

    var product = await _context.GetProductWithFeatures(1).Where(x => x.Width > 100).ToListAsync();



    var categories = await _context.Categories.Select(x => new
    {
        CategoryName = x.Name,
        ProductCount = _context.GetProductCount(x.Id)
    }).Where(x => x.ProductCount > 10).ToListAsync();

    int categoryId = 1;
    var productCount = _context.ProductCount.FromSqlInterpolated($"select  dbo.fc_get_product_count({categoryId}) as Count").First().Count2;


    Console.WriteLine("");

    #region Data Insert
    //var category = new Category() { Name = "Defterler" };
    //category.Products.Add(new() { Name = "Defter 1", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "Defter 2", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "Defter 3", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "Defter 4", Price = 100, Stock = 200, Barcode = 123 });
    //_context.Categories.Add(category);
    //_context.SaveChanges();
    #endregion




}




