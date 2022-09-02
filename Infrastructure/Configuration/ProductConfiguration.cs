using Core.Entities.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p=>p.Id).IsRequired();
            builder.Property(p=>p.Title).HasMaxLength(200);
            builder.Property(p=>p.Description).HasMaxLength(500);

            builder.HasOne(p=>p.Brand).WithMany().HasForeignKey(p=>p.BrandId);
            builder.HasOne(p=>p.Category).WithMany().HasForeignKey(p=>p.CategoryId);
        }
    }
}