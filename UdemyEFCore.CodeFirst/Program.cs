// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();
using (var _context = new AppDbContext())
{
    var products = _context.Products.ToList();

    products.ForEach(p =>
    {
        p.Stock += 100;
    });
    _context.ChangeTracker.Entries().ToList().ForEach(e =>
    {
        if (e.Entity is Product p)
        {
            Console.WriteLine(e.State);
        }
    });

    _context.SaveChanges();

    // _context.SaveChanges();

    // var products = await _context.Products.AsNoTracking().ToListAsync();

    //products.ForEach(p =>
    //{
    //    Console.WriteLine($"{p.Id} :{p.Name} - {p.Price} - {p.Stock}");
    //});
}