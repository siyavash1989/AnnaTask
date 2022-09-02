using Core.Entities.Store.Invoice;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.OwnsOne(o => o.ShippingAddress, a =>
            {
                a.WithOwner();
            });
            builder.Property(s => s.Status)
                .HasConversion(
                    o => o.ToString(),
                    o => (InvoiceStatus)Enum.Parse(typeof(InvoiceStatus), o)
                );
            builder.HasMany(o=>o.InvoiceItems).WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}