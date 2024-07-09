using FiscalLabService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiscalLabService.Repository.PostgreSql.Context;

public class ImageConfig : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("images"); 
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasMaxLength(36);
        
        builder.Property(p => p.VisitId)
            .IsRequired()
            .HasColumnName("visit_id")
            .HasMaxLength(36);
        
        builder.Property(p => p.Data)
            .HasColumnName("data")
            .HasColumnType("BYTEA")
            .IsRequired();
        
        builder.Property(e => e.Name)
            .HasColumnName("name")
            .IsRequired();
        
        builder.Property(e => e.Description)
            .HasColumnName("description")
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
    }
}