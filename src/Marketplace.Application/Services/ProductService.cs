using AutoMapper;
using Marketplace.Application.ErrorMessages;
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
                throw new NotFoundException(ProductErrorMessages.ProductsNotFound);
            }
            return _mapper.Map<IEnumerable<ProductModel>>(products);
        }

        public async Task<ProductModel> GetProductById(Guid id)
        {
            var entity = await _productRepository.GetFirstAsync(p => p.Id.ToString() == id.ToString());
            if (entity == null)
            {
                throw new Exception(ProductErrorMessages.ProductWithIdNotFound);
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
                throw new BadRequestException(ProductErrorMessages.ProductDoesNotBelong);
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
                throw new BadRequestException(ProductErrorMessages.ProductDoesNotBelong);
            }

            await _productRepository.DeleteAsync(product);

            return new Response { Status = "Success", Message = "Product delete successfully!" };
        }

        public IEnumerable<ProductModel> GetProductsBySellerId(Guid id)
        {
            var products = _productRepository.GetWhere(p => p.SellerId == id).ToList();

            if (products.Count == 0)
            {
                throw new NotFoundException(ProductErrorMessages.ProductsNotFound);
            }

            return _mapper.Map<IEnumerable<ProductModel>>(products);
        }

        public IEnumerable<ProductModel> GetFilteredProducts(GetProductsFilter getProductsFilter)
        {
            if (getProductsFilter.FilterValue == null)
            {
                throw new BadRequestException(ProductErrorMessages.FieldCanNotBeEmpty);
            }

            return _mapper.Map<IEnumerable<ProductModel>>(
                getProductsFilter.FilterBy switch
                {
                    "Name" => _productRepository.GetWhere(x => x.Name == getProductsFilter.FilterValue).ToList(),
                    "Rate" => _productRepository.GetWhere(x => (int)x.Rate == int.Parse(getProductsFilter.FilterValue)).ToList(),
                    "Price" => _productRepository.GetWhere(x => (decimal)x.Price == decimal.Parse(getProductsFilter.FilterValue)).ToList(),
                    _ => _productRepository.GetAll().AsParallel().ToList()
                });
        }

        public IEnumerable<ProductModel> SearchProductsBySellerId(Guid id, SearchProductModel model)
        {
            if (model.Name == null)
            {
                throw new BadRequestException(ProductErrorMessages.FieldCanNotBeEmpty);
            }

            var products = _productRepository.GetWhere(p => 
                p.Name.Contains(model.Name) && p.SellerId == id).ToList();

            if (products.Count == 0)
            {
                throw new NotFoundException(ProductErrorMessages.ProductsNotFound);
            }

            return _mapper.Map<IEnumerable<ProductModel>>(products);
        }
    }
}
