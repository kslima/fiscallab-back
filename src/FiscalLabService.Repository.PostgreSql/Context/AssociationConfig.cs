using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiscalLabService.Repository.PostgreSql.Context;

public class AssociationConfig : IEntityTypeConfiguration<Association>
{
    public void Configure(EntityTypeBuilder<Association> builder)
    {
        builder.ToTable("associations");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasMaxLength(36);

        builder.Property(a => a.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasMaxLength(128);

        builder
            .OwnsOne(a => a.Address)
            .Property(a => a.City)
            .HasColumnName("city")
            .HasMaxLength(64)
            .IsRequired();

        builder
            .OwnsOne(a => a.Address)
            .Property(a => a.State)
            .HasColumnName("state")
            .HasMaxLength(2)
            .IsRequired();

        builder
            .Property(a => a.Emails)
            .HasConversion(v => string.Join(";", v.Select(e => e.Address)),
                v => v
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => new Email(x))
                    .ToList())
            .IsRequired();
    }
}