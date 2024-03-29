﻿using GB.ApiDotNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GB.ApiDotNet6.Infra.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("produto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("idproduto")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnName("nome");

            builder.Property(x => x.CodErp)
                .HasColumnName("coderp");

            builder.Property(x => x.Price)
                .HasColumnName("preco");

            builder.HasMany(x => x.Purchases)
                .WithOne(p => p.Product)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
