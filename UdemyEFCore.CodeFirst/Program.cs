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

    //var productsDto = _context.Products.Select(x => new ProductDto()
    //{
    //    Id = x.Id,
    //    Name = x.Name,
    //    Price = x.Price,
    //    DiscountPrice = x.DiscountPrice,
    //    Stock = x.Stock


    //}).ToList();


    // var product = _context.Products.ToList();

    //var productDto = ObjectMapper.Mapper.Map<List<ProductDto>>(product);

    var productDto = _context.Products.ProjectTo<ProductDto>(ObjectMapper.Mapper.ConfigurationProvider).Where(x => x.Price > 10).ToList();




    Console.WriteLine("");











    //var products = await _context.Products.Select(x => new ProductDto
    //{
    //    CategoryName = x.Category.Name,
    //    ProductName = x.Name,
    //    ProductPrice = x.Price,
    //    Width = (int?)x.ProductFeature.Width


    //}).Where(x => x.Width > 10).ToListAsync();



    //var categories = _context.Categories.Select(x => new ProductDto2
    //{
    //    CategoryName = x.Name,
    //    ProductNames = String.Join(",", x.Products.Select(z => z.Name)),
    //    TotalPrice = x.Products.Sum(x => x.Price),
    //    TotalWidth = (int?)x.Products.Select(x => x.ProductFeature.Width).Sum()

    //}
    //).Where(y => y.TotalPrice > 100).OrderBy(x => x.TotalPrice).ToList();






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




