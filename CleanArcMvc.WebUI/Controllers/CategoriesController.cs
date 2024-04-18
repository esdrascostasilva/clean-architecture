using CleanArcMvc.Application;
using CleanArcMvc.Application.DTOs;
using CleanArcMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArcMvc.WebUI.Controllers;

public class CategoriesController : Controller
{   
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService service)
    {
        _categoryService = service;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetCategories();
        return View(categories);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryDTO categoryDTO)
    {
        if(ModelState.IsValid)
        {
            await _categoryService.Create(categoryDTO);
            return RedirectToAction(nameof(Index));
        }
        return View(categoryDTO);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if(id == null)
            return NotFound();
        
        var categoryDTO = await _categoryService.GetCategoryById(id);

        if(categoryDTO == null) 
            return NotFound();

        return View(categoryDTO);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
    {
        if(ModelState.IsValid)
        {
            try
            {
                await _categoryService.Update(categoryDTO);
            }
            catch(Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(categoryDTO);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if(id == null) return NotFound();
        
        var categoryDTO = await _categoryService.GetCategoryById(id);

        if(categoryDTO == null) return NotFound();

        return View(categoryDTO);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        await _categoryService.Remove(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if(id == null) return NotFound();
        
        var categoryDTO = await _categoryService.GetCategoryById(id);

        if(categoryDTO == null) return NotFound();

        return View(categoryDTO);
    }
}
