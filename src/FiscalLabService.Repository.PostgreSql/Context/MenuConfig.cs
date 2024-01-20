using FiscalLabService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiscalLabService.Repository.PostgreSql.Context;

public class MenuConfig : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("menus");

        builder.HasKey(m => m.Id);
        
        builder.Property(m => m.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasMaxLength(36);
        
        builder.Property(m => m.Page)
            .IsRequired()
            .HasColumnName("page")
            .HasMaxLength(128);
        
        builder.Property(m => m.Code)
            .IsRequired()
            .HasColumnName("code")
            .HasMaxLength(128);

        builder
            .OwnsMany(m => m.Options, option =>
            {
                option.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .UseIdentityByDefaultColumn();

                option
                    .WithOwner()
                    .HasForeignKey("menu_id");
                option.ToTable("options")
                    .Property(e => e.Description)
                    .HasColumnName("description")
                    .IsRequired();
            });
    }
}