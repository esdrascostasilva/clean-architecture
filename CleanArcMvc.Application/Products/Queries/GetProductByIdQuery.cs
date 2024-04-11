using CleanArcMvc.Domain;
using CleanArcMvc.Domain.Entities;
using MediatR;

namespace CleanArcMvc.Application.Products.Queries;

public class GetProductByIdQuery : IRequest<Product>
{
    public int Id { get; set; }

    public GetProductByIdQuery(int id)
    {
        Id = id;
    }
}
