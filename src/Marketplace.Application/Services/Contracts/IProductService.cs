using Marketplace.Application.Helpers;
using Marketplace.Application.Models.Product;

namespace Marketplace.Application.Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAllProducts();
        Task<ProductModel> GetProductById(Guid id);
        Task<CreateProductModel> AddProductAsync(CreateProductModel model, string sellerId);
        Task<UpdateProductModel> UpdateProductAsync(Guid id, UpdateProductModel model, string sellerId);
        Task<Response> DeleteProductAsync(Guid id, string sellerId);
    }
}
