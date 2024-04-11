using CleanArcMvc.Domain;
using CleanArcMvc.Domain.Entities;
using CleanArcMvc.Domain.Interfaces;
using CleanArcMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArcMvc.Infra.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    ApplicationDbContext _categoryContext;
    public CategoryRepository(ApplicationDbContext context)
    {
        _categoryContext = context;
    }

    public async Task<Category> CreateCategoryAsync(Category category)
    {
        _categoryContext.Add(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _categoryContext.Categories.ToListAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int? id)
    {
        return await _categoryContext.Categories.FindAsync(id);
    }

    public async Task<Category> RemoveCategoryAsync(Category category)
    {   
        _categoryContext.Remove(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        _categoryContext.Update(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }
}
