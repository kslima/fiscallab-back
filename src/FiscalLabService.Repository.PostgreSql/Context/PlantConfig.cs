﻿using FiscalLabService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiscalLabService.Repository.PostgreSql.Context;

public class PlantConfig : IEntityTypeConfiguration<Plant>
{
    public void Configure(EntityTypeBuilder<Plant> builder)
    {
        builder.ToTable("plants");

        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id");
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnName("name");

        builder
            .OwnsOne(p => p.Address)
            .Property(a => a.City)
            .HasColumnName("address")
            .IsRequired();
        
        builder
            .OwnsOne(p => p.Address)
            .Property(a => a.State)
            .HasColumnName("state")
            .IsRequired();
    }
}