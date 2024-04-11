﻿using CleanArcMvc.Application;
using CleanArcMvc.Application.Interfaces;
using CleanArcMvc.Application.Mappings;
using CleanArcMvc.Application.Services;
using CleanArcMvc.Domain;
using CleanArcMvc.Domain.Interfaces;
using CleanArcMvc.Infra.Data;
using CleanArcMvc.Infra.Data.Context;
using CleanArcMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArcMvc.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
            x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
    }
}
