using CleanArcMvc.Application.DTOs;
using CleanArcMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArcMvc.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService) 
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
    {
        var categories = await _productService.GetProducts();

        if(categories == null)  
            return NotFound("Products not found");
        
        return Ok(categories);
    }

    [HttpGet("{id:int}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDTO>> Get(int id)
    {
        var category = await _productService.GetProductById(id);

        if(category == null)
            return NotFound("Category not found.");

        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
    {
        if(productDTO == null)
            return BadRequest("Invalid data.");
        
        await _productService.Add(productDTO);

        return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
    }

    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] ProductDTO ProductDTO)
    {
        if(id != ProductDTO.Id)
            return BadRequest();
        
        if(ProductDTO == null)
            return BadRequest();

        await _productService.Update(ProductDTO);

        return Ok(ProductDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ProductDTO>> Delete(int id)
    {
        var category = await _productService.GetProductById(id);

        if(category == null)
            return NotFound("Category not found.");
        
        await _productService.Remove(id);

        return Ok(category);
    }
}