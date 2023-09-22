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
        private readonly ILogger _logger;
        public ProductController(ChimallidbContext dbService, ILogger<ProductController> logger)
        {
            _dbService = dbService;
            _logger = logger;
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

        [HttpGet("related")]
        public async Task<ActionResult<List<Product>>> GetRelatedProductos()
        {

            Random random = new Random();
            // Number of random elements you want to retrieve
            int numberOfRandomElements = 5; // Change this as needed

            try
            {
                if (_dbService.Products == null)
                {
                    return NotFound();
                }
                var myList = await _dbService.Products.ToListAsync();

                List<Product> randomElements = new List<Product>();

                for (int i = 0; i < numberOfRandomElements; i++)
                {
                    // Generate a random index within the bounds of the list
                    int randomIndex = random.Next(0, myList.Count);
                    // Retrieve the element at the random index and add it to the result list
                    var randomElement = myList[randomIndex];
                    if (randomElements.Contains(randomElement))
                    {
                        randomIndex = random.Next(0, myList.Count);
                        randomElement = myList[randomIndex];
                    }
                    randomElements.Add(randomElement);
                    //await Console.Out.WriteLineAsync(randomElement.ToString());
                }
                return randomElements.Distinct().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "API request failed: {Error}", ex.Message);
                throw;
            }


        }
    }
}
