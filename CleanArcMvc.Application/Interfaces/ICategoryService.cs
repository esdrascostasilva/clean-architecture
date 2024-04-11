using CleanArcMvc.Application.DTOs;

namespace CleanArcMvc.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategories();
    Task<CategoryDTO> GetCategoryById(int? id);
    Task Create(CategoryDTO categoryDTO);
    Task Update(CategoryDTO categoryDTO);
    Task Remove(int? id);
}
