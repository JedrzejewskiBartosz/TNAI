using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNAI.Dto.Products;
using TNAI.Model.Entities;
using TNAI.Repository.Products;

namespace TNAI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var product = await _productRepository.GetAllProductsAsync();
            if (!product.Any()) return NotFound();

            return Ok(product);
        }


        [HttpPost]

        public async Task<IActionResult> Post([FromBody] ProductInputDto product)
        {
            if (product == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newProduct = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                ImageFile = product.ImageFile
            };

            var result = await _productRepository.SaveProductAsync(newProduct);
            if (!result) throw new Exception("ERROR save");

            return Ok(newProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductInputDto product)
        {
            if (product == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingProduct = await _productRepository.GetProductByIdAsync(id);
            if (existingProduct == null) return NotFound();

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.ImageFile = product.ImageFile;

            var result = await _productRepository.SaveProductAsync(existingProduct);
            if (!result) throw new Exception("ERROR upt");

            return Ok(existingProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(id);
            if (existingProduct == null) return NotFound();

            var result = await _productRepository.DeleteProductAsync(id);
            if (!result) throw new Exception("ERROR del");

            return Ok();
        }
    }
}
