using FiscalLabService.Domain.Entities;
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
            .HasColumnName("id")
            .HasMaxLength(36);
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasMaxLength(128);
        
        builder.Property(p => p.Cnpj)
            .IsRequired()
            .HasColumnName("cnpj")
            .HasMaxLength(14);

        builder
            .OwnsOne(p => p.Address)
            .Property(a => a.City)
            .HasColumnName("address")
            .HasMaxLength(64)
            .IsRequired();
        
        builder
            .OwnsOne(p => p.Address)
            .Property(a => a.State)
            .HasColumnName("state")
            .HasMaxLength(2)
            .IsRequired();
    }
}