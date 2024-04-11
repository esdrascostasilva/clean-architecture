using AutoMapper;
using CleanArcMvc.Application.DTOs;
using CleanArcMvc.Application.Interfaces;
using CleanArcMvc.Domain;
using CleanArcMvc.Domain.Entities;
using CleanArcMvc.Domain.Interfaces;

namespace CleanArcMvc.Application.Services;

public class ProductService : IProductService
{
    private IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repository, IMapper mapper)
    {
        _productRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productsEntity = await _productRepository.GetProductsAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
    }

    public async Task<ProductDTO> GetProductById(int? id)
    {
        var productEntity = await _productRepository.GetProductByIdAsync(id);
        return _mapper.Map<ProductDTO>(productEntity);
    }

    public async Task<ProductDTO> GetProductCategory(int? id)
    {
        var productEntity = await _productRepository.GetProductCategoryAsync(id);
        return _mapper.Map<ProductDTO>(productEntity);
    }

    public async Task Add(ProductDTO productDTO)
    {
        var productEntity = _mapper.Map<Product>(productDTO);
        await _productRepository.CreateProductAsync(productEntity);
    }

    public async Task Update(ProductDTO productDTO)
    {
        var productEntity = _mapper.Map<Product>(productDTO);
        await _productRepository.UpdateProductAsync(productEntity);
    }

    public async Task Remove(int? id)
    {
        var productEntity = _productRepository.GetProductByIdAsync(id).Result;
        await _productRepository.DeleteProductAsync(productEntity);
    }
}
