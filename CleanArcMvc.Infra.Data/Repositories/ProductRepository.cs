using CleanArcMvc.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArcMvc.Infra.Data;

public class ProductRepository : IProductRepository
{
    ApplicationDbContext _productContext;

    public ProductRepository(ApplicationDbContext context)
    {
        _productContext = context;
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        _productContext.Add(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> DeleteProductAsync(Product product)
    {
        _productContext.Remove(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> GetProductByIdAsync(int? id)
    {
        return await _productContext.Products.FindAsync(id);
    }

    public async Task<Product> GetProductCategoryAsync(int? id)
    {
        return await _productContext.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _productContext.Products.ToListAsync();
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        _productContext.Update(product);
        await _productContext.SaveChangesAsync();
        return product;
    }
}
