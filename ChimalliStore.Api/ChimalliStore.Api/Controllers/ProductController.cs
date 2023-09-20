using ChimalliStore.Api.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChimalliStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ChimallidbContext _dbService;

        public ProductController(ChimallidbContext dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProductos()
        {
            if (_dbService.Products == null)
            {
                return NotFound();
            }
            return await _dbService.Products.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CrearProducto(Product product) {
            if (_dbService.Products == null)
            {
                return Problem("Entity set 'ChimallidbContext.Products'  is null.");
            }
            _dbService.Products.Add(product);
            await _dbService.SaveChangesAsync();
            return Ok(product);
            //return CreatedAtAction("GetProduct", new { id = product.ProductId}, product);
        }
    }
}
