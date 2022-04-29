// See https://aka.ms/new-console-template for more information

using AutoMapper.QueryableExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;
using UdemyEFCore.CodeFirst.DTOs;
using UdemyEFCore.CodeFirst.Mappers;
using UdemyEFCore.CodeFirst.Models;

Initializer.Build();


var connection = new SqlConnection(Initializer.Configuration.GetConnectionString("SqlCon"));

IDbContextTransaction transaction = null;
var _context = new AppDbContext(connection);



transaction = _context.Database.BeginTransaction();



var category = new Category() { Name = "Kılıflar" };

_context.Categories.Add(category);
_context.SaveChanges();

Product product = new()
{
    Name = "Kılıf 2",
    Price = 100,
    Stock = 200,
    Barcode = 123,
    DiscountPrice = 100,
    CategoryId = category.Id
};

_context.Products.Add(product);

_context.SaveChanges();


#region Data Insert
//var category = new Category() { Name = "Defterler" };
//category.Products.Add(new() { Name = "Defter 1", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
//category.Products.Add(new() { Name = "Defter 2", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
//category.Products.Add(new() { Name = "Defter 3", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
//category.Products.Add(new() { Name = "Defter 4", Price = 100, Stock = 200, Barcode = 123 });
//_context.Categories.Add(category);
//_context.SaveChanges();
#endregion


var dbContext2 = new AppDbContext(connection);


dbContext2.Database.UseTransaction(transaction.GetDbTransaction());


var product3 = dbContext2.Products.First();
product3.Stock = 1000;
dbContext2.SaveChanges();




transaction.Commit();
_context.Dispose();
dbContext2.Dispose();


transaction.Dispose();
Console.WriteLine("");












