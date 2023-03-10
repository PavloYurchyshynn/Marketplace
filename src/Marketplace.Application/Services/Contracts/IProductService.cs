using Marketplace.Application.Helpers;
using Marketplace.Application.Models.Product;

namespace Marketplace.Application.Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAllProducts();
        Task<ProductModel> GetProductById(Guid id);
        Task<CreateProductModel> AddProductAsync(CreateProductModel model);
        Task<UpdateProductModel> UpdateProductAsync(Guid id, UpdateProductModel model);
        Task<Response> DeleteProductAsync(Guid id);
        IEnumerable<ProductModel> GetProductsBySellerId(Guid id);
        IEnumerable<ProductModel> GetFilteredProducts(GetProductsFilter getProductsFilter);
        IEnumerable<ProductModel> SearchProductsBySellerId(Guid id, SearchProductModel model);

    }
}
