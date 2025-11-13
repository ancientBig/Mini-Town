using kasiShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kasiShop.Persistence
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Define table name
            builder.ToTable("Products","shop");

            // Set primary key
            builder.HasKey(m => m.ProductID);

            // Configure properties
            builder.Property(m => m.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(m => m.Description)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(m => m.Price)
                   .IsRequired();
        }
    }
}
