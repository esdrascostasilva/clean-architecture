﻿using CleanArcMvc.Domain;
using CleanArcMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArcMvc.Infra.Data.EntitiesConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
       builder.HasKey(c => c.Id);
       builder.Property(c => c.Name).HasMaxLength(100).IsRequired();

       builder.HasData(
            new Category(1, "Material Escolar"),
            new Category(2, "Eletronicos"),
            new Category(3, "Acessorios")
       );
    }
}
