using FiscalLabService.Domain.Entities;
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
            .OwnsMany(a => a.Emails, email =>
            {
                email.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .UseIdentityByDefaultColumn();

                email
                    .WithOwner()
                    .HasForeignKey("association_id");
                email.ToTable("emails")
                    .Property(e => e.Address)
                    .HasColumnName("email_address")
                    .HasMaxLength(255)
                    .IsRequired();
            });
    }
}