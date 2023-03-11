using AutoMapper;
using Marketplace.Application.Exceptions;
using Marketplace.Application.Helpers;
using Marketplace.Application.Models.Product;
using Marketplace.Application.Services.Contracts;
using Marketplace.Core.Entities;
using Marketplace.DataAccess.Repositories.Contracts;
using Marketplace.Shared.Services.Contracts;

namespace Marketplace.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IClaimService _claimService;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper, IClaimService claimService)
        {
            _claimService = claimService;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            var products = _productRepository.GetAll().AsParallel().ToList();
            if (products == null)
            {
                throw new Exception("Products not found");
            }
            return _mapper.Map<IEnumerable<ProductModel>>(products);
        }

        public async Task<ProductModel> GetProductById(Guid id)
        {
            var entity = await _productRepository.GetFirstAsync(p => p.Id.ToString() == id.ToString());
            if (entity == null)
            {
                throw new Exception("Product with this id not found");
            }
            return _mapper.Map<ProductModel>(entity);
        }

        public async Task<CreateProductModel> AddProductAsync(CreateProductModel createProductModel)
        {
            string sellerId = _claimService.GetUserId();
            var entity = _mapper.Map<Product>(createProductModel);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            entity.SellerId = Guid.Parse(sellerId);

            await _productRepository.AddAsync(entity);
            return _mapper.Map<CreateProductModel>(entity);
        }

        public async Task<UpdateProductModel> UpdateProductAsync(Guid id, UpdateProductModel model)
        {
            string sellerId = _claimService.GetUserId();
            var product = await _productRepository.GetFirstAsync(p => p.Id.ToString() == id.ToString());

            if (sellerId != product.SellerId.ToString())
            {
                throw new BadRequestException("The selected product does not belong to you");
            }

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;

            var updatedProduct = await _productRepository.UpdateAsync(product);

            return _mapper.Map<UpdateProductModel>(updatedProduct);
        }

        public async Task<Response> DeleteProductAsync(Guid id)
        {
            string sellerId = _claimService.GetUserId();
            var product = await _productRepository.GetFirstAsync(p => p.Id.ToString() == id.ToString());

            if (sellerId != product.SellerId.ToString())
            {
                throw new BadRequestException("The selected product does not belong to you");
            }

            await _productRepository.DeleteAsync(product);

            return new Response { Status = "Success", Message = "Product delete successfully!" };
        }
    }
}
