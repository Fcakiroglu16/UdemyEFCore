// See https://aka.ms/new-console-template for more information

using AutoMapper.QueryableExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;
using UdemyEFCore.CodeFirst.DTOs;
using UdemyEFCore.CodeFirst.Mappers;
using UdemyEFCore.CodeFirst.Models;

Initializer.Build();





using (var _context = new AppDbContext())
{





    using (var transaction = _context.Database.BeginTransaction())
    {


        var category = new Category() { Name = "Kılıflar" };

        _context.Categories.Add(category);
        _context.SaveChanges();

        Product product = new()
        {
            Name = "Kılıf 1",
            Price = 100,
            Stock = 200,
            Barcode = 123,
            DiscountPrice = 100,
            CategoryId = category.Id
        };

        _context.Products.Add(product);

        _context.SaveChanges();


        transaction.Commit();



    }









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




