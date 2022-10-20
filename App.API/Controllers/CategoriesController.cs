using App.API.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using UdemyEFCore.CodeFirst.DAL;

namespace App.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }




        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await GetAll());

        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetWithAsEnumerable()
        {
            return Ok(GetAllWithAsEnumerable());

        }
        [HttpGet]
        public  ActionResult<IAsyncEnumerable<CategoryDto>> GetWithAsAsyncEnumerable()
        {
            return Ok(GetAllWithAsAsyncEnumerable());

        }


        [NonAction]
        public  Task<List<CategoryDto>> GetAll()
        {

            return _context.Categories.Select(x => new CategoryDto()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }
        [NonAction]
        public IEnumerable<CategoryDto> GetAllWithAsEnumerable()
        {

            return _context.Categories.Select(x => new CategoryDto()
            {
                Id = x.Id,
                Name = x.Name
            }).AsEnumerable();


        }
        [NonAction]
        public IAsyncEnumerable<CategoryDto> GetAllWithAsAsyncEnumerable()
        {

            return _context.Categories.Select(x => new CategoryDto()
            {
                Id = x.Id,
                Name = x.Name
            }).AsAsyncEnumerable();


        }
       
    }
}
