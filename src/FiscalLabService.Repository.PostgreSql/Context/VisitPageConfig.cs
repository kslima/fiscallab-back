using FiscalLabService.Domain.Entities;
using FiscalLabService.Repository.PostgreSql.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiscalLabService.Repository.PostgreSql.Context;

public class VisitPageConfig(SeedDataOptions seedDataOptions) : IEntityTypeConfiguration<VisitPage>
{
    public void Configure(EntityTypeBuilder<VisitPage> builder)
    {
        builder.ToTable("visit_pages");

        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasMaxLength(36);
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasMaxLength(128);
        
        builder.Property(p => p.DisplayName)
            .IsRequired()
            .HasColumnName("display_name")
            .HasMaxLength(128);

        builder.HasData(seedDataOptions.VisitPages);
    }
}