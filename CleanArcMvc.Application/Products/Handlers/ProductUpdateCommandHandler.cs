﻿

using CleanArcMvc.Application.Products.Commands;
using CleanArcMvc.Domain.Entities;
using CleanArcMvc.Domain.Interfaces;
using MediatR;

namespace CleanArcMvc.Application.Products.Handlers;

public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
{
    private readonly IProductRepository _productRepository;

    public ProductUpdateCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductByIdAsync(request.Id);

        if(product == null)
            throw new ApplicationException("Entity could not be found");
        
        else
        {
            product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
            return await _productRepository.UpdateProductAsync(product);
        }
    }
}
