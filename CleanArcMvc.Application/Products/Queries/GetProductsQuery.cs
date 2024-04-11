using CleanArcMvc.Domain;
using CleanArcMvc.Domain.Entities;
using MediatR;

namespace CleanArcMvc.Application.Products.Queries;

public class GetProductsQuery : IRequest<IEnumerable<Product>>
{
}
