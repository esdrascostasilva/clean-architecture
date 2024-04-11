using CleanArcMvc.Domain;
using MediatR;

namespace CleanArcMvc.Application;

public class ProductRemoveCommand : IRequest<Product>
{
    public int Id { get; set; }

    public ProductRemoveCommand(int id)
    {
        Id = id;
    }
}
