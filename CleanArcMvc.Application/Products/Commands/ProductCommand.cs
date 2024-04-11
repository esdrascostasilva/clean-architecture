using CleanArcMvc.Domain;
using MediatR;

namespace CleanArcMvc.Application;

public abstract class ProductCommand : IRequest<Product>
{
    public string Name { get; set; }
    public string Descrition { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Image { get; set; }
    public int CategoryId { get; set; }
}
