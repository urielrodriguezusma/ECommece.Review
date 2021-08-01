using Ecommerce.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder) 
        {
            builder.Property(d => d.Id).IsRequired();
            builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Description).IsRequired().HasMaxLength(180);
            builder.Property(d => d.Price).HasColumnType("decimal(18,2)");

            // Un producto esta asociado a un brand. Usamos la
            // propiedad de navegación (Y un tipo de brand esta asociado a muchos productos)
            builder.HasOne(d => d.ProductBrand).WithMany()
                   .HasForeignKey(d => d.ProductBrandId);

            builder.HasOne(d => d.ProductType).WithMany()
                   .HasForeignKey(d => d.ProductTypeId);
                   
        }
    }
}
