﻿using CleanArcMvc.Domain;
using CleanArcMvc.Domain.Entities;
using MediatR;

namespace CleanArcMvc.Application.Products.Commands;

public abstract class ProductCommand : IRequest<Product>
{
    public string Name { get; set; }
    public string Descrition { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Image { get; set; }
    public int CategoryId { get; set; }
}
