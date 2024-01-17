// using FiscalLabService.Domain.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace FiscalLabService.Repository.SqLite.Context;
//
// public class PlantEmailConfig : IEntityTypeConfiguration<PlantEmail>
// {
//     public void Configure(EntityTypeBuilder<PlantEmail> builder)
//     {
//         builder.ToTable("plant_emails");
//
//         builder.HasKey(p => p.Id);
//         builder.Property(p => p.Id)
//             .IsRequired()
//             .HasColumnName("id");
//         
//         builder.Property(p => p.PlantId)
//             .IsRequired()
//             .HasColumnName("plant_id");
//         
//         builder.Property(p => p.Address)
//             .IsRequired()
//             .HasColumnName("address");
//     }
// }