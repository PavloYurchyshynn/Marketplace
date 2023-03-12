using Marketplace.Application;
using Marketplace.Application.Models.Product;
using Marketplace.Application.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.API.Controllers
{
    [Authorize]
    [Route("api/products")]
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
                var product = await _productService.AddProductAsync(model);
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
                var updatedProduct = await _productService.UpdateProductAsync(id, model);
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
                var response = await _productService.DeleteProductAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("seller/{id}")]

        public IActionResult GetSellerProducts(Guid id)
        {
            try
            {
                var products = _productService.GetSellerProducts(id);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("filter")]
        public IActionResult GetFilteredProducts(GetProductsFilter filter)
        {
            try
            {
                var products = _productService.GetFilteredProducts(filter);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("search/{id}")]
        public IActionResult SearchSellerProducts(Guid id, SearchProductModel model)
        {
            try
            {
                var products = _productService.SearchSellerProducts(id, model);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
