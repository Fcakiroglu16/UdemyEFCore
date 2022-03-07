// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();
using (var _context = new AppDbContext())
{
    var category = await _context.Categories.FirstAsync();

    Console.WriteLine("category çekildi");
    var produts = category.Products;

    foreach (var item in produts)
    {
        // (N+1 Problem)
        var productFeature = item.ProductFeature;
    }
    Console.WriteLine("işlem bitti.");
}