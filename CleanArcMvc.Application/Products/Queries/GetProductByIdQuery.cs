using CleanArcMvc.Domain;
using MediatR;

namespace CleanArcMvc.Application;

public class GetProductByIdQuery : IRequest<Product>
{
    public int Id { get; set; }

    public GetProductByIdQuery(int id)
    {
        Id = id;
    }
}
