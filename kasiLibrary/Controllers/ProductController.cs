using kasiShop.Entities.Model;
using kasiShop.Service;
using Microsoft.AspNetCore.Mvc;


namespace kasiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpDelete]
        [Route("v1/remove-product")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            await productService.RemoveProductById(productId);
            return Ok("Product Deleted successfully");
        }

        [HttpGet]
        [Route("v1/get-product")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            var product = await productService.GetProduct(productId);
            return Ok(product);
        }

        [HttpPost]
        [Route("v1/add-product")]
        public async Task<IActionResult> AddProduct(ProductInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please provide all the required fields");
            }

            var product = await productService.AddProduct(model);
            return Ok("Successfully added product!");
        }

        [HttpPut]
        [Route("v1/update-product")]
        public async Task<IActionResult> UpdateProduct(ProductUpdateInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await productService.UpdateProduct(model);
            return Ok(product);
        }
    }
}
