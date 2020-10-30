using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using api.Data;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("v1/categories")]
    public class ProductController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] Context context)
        {
            var products = await context.Products.Include(x => x.Category).ToListAsync();
            return products;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Product>>> GetById([FromServices] Context context, int id)
        {
            var product = await context.Products
            .Include(x => x.Category)
            .AsNoTracking()
            .Where(x => x.CategoryId == id)
            .ToListAsync();
            return product;
        }

        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategory([FromServices] Context context, int id)
        {
            var products = await context.Products
            .Include(x => x.Category)
            .AsNoTracking()
            .ToListAsync();

            return products;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post(
            [FromServices] Context context,
            [FromBody] Product model
        )
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}