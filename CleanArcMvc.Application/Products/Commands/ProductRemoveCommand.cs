using CleanArcMvc.Domain;
using CleanArcMvc.Domain.Entities;
using MediatR;

namespace CleanArcMvc.Application.Products.Commands;

public class ProductRemoveCommand : IRequest<Product>
{
    public int Id { get; set; }

    public ProductRemoveCommand(int id)
    {
        Id = id;
    }
}
