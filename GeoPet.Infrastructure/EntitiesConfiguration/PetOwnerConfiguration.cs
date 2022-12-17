using GeoPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoPet.Infrastructure.EntitiesConfiguration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<PetOwner>
    {
        public void Configure(EntityTypeBuilder<PetOwner> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Password).HasMaxLength(100).IsRequired();

            builder.HasData(
              new PetOwner(1, "Diogo", "diogo@diogo.com", "123456"),
              new PetOwner(2, "Juliana", "juliana@juliana.com", "123456"),
              new PetOwner(3, "Olivia", "olivia@olvia.com", "123456")
            );
        }
    }
}
