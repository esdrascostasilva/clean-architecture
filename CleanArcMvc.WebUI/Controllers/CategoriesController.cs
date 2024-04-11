using CleanArcMvc.Application;
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
}
