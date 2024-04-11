
using AutoMapper;
using CleanArcMvc.Application.DTOs;
using CleanArcMvc.Application.Interfaces;
using CleanArcMvc.Domain.Entities;
using CleanArcMvc.Domain.Interfaces;

namespace CleanArcMvc.Application.Services;

public class CategoryService : ICategoryService
{
    private ICategoryRepository _categoryRepositiry;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepositiry = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categoriesEntity = await _categoryRepositiry.GetCategoriesAsync();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }
   
    public async Task<CategoryDTO> GetCategoryById(int? id)
    {
        var categoryEntity = await _categoryRepositiry.GetCategoryByIdAsync(id);
        return _mapper.Map<CategoryDTO>(categoryEntity);
    }

    public async Task Create(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRepositiry.CreateCategoryAsync(categoryEntity);  
    }

    public async Task Update(CategoryDTO categoryDTO)
    {
       var categoryEntity = _mapper.Map<Category>(categoryDTO);
       await _categoryRepositiry.UpdateCategoryAsync(categoryEntity);
    }

    public async Task Remove(int? id)
    {
        var categoryEntity = _categoryRepositiry.GetCategoryByIdAsync(id).Result;
        await _categoryRepositiry.RemoveCategoryAsync(categoryEntity);
    }
}

