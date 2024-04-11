using CleanArcMvc.Domain;
using MediatR;

namespace CleanArcMvc.Application;

public class GetProductsQuery : IRequest<IEnumerable<Product>>
{
}
