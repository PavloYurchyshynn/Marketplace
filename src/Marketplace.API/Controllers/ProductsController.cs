using Marketplace.Application;
using Marketplace.Application.Models.Product;
using Marketplace.Application.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.API.Controllers
{
    [Authorize]
    [Route("api/product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetProductById(Guid id)
        {
            try
            {
                var product = await _productService.GetProductById(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = UserRoles.Seller)]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateProduct(CreateProductModel model)
        {
            try
            {
                var sellerId = User.Claims.First(x => x.Type == "User id").Value;
                var product = await _productService.AddProductAsync(model, sellerId);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = UserRoles.Seller)]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, UpdateProductModel model)
        {
            try
            {
                var sellerId = User.Claims.First(x => x.Type == "User id").Value;
                var updatedProduct = await _productService.UpdateProductAsync(id, model, sellerId);
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = UserRoles.Seller)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReportById(Guid id)
        {
            try
            {
                var sellerId = User.Claims.First(x => x.Type == "User id").Value;
                var response = await _productService.DeleteProductAsync(id, sellerId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
