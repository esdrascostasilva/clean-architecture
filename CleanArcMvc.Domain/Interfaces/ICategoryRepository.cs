using CleanArcMvc.Domain.Entities;

namespace CleanArcMvc.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int? id);
    Task<Category> CreateCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Category category);
    Task<Category> RemoveCategoryAsync(Category category);

}
