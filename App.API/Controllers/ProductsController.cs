using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst.DAL;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var product = new Product() { Name = "pen 1", Price = 100, DiscountPrice = 50, Barcode = 123, CategoryId = 1, Stock = 20 };

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return Ok("Created");
        }

        [HttpPut]
        public async Task<IActionResult> Put()
        {
            var product = await _context.Products.FirstAsync();

            product.Name = "pen 10";

            await _context.SaveChangesAsync();

            return Ok("Updated");
        }
    }
}