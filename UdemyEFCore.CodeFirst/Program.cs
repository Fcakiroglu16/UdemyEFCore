// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;
using UdemyEFCore.CodeFirst.Models;

Initializer.Build();

GetProducts(1, 5).ForEach(x =>
 {
     Console.WriteLine($"{x.Id} {x.Name} {x.Price}");

 });




static List<Product> GetProducts(int page, int pageSize)
{

    using (var _context = new AppDbContext())
    {

        // page=1 pageSize=3 => ilk 3 data => skip :0 take:3 (page-1)*pageSize) =>(1-1)*3 :0
        // page=2 pageSize=3 => ilk 3 data  => skip:3 take:3 (page-1)*pageSize) =>(2-1)*3 :3
        // page=3 pageSize=3 => ilk 3 data  => skip:6 take:3 (page-1)*pageSize) =>(2-1)*3 :6
        return _context.Products.Where(x => x.Price > 100).OrderByDescending(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();







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
}



