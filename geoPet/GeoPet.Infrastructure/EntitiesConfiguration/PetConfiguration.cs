using GeoPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoPet.Infrastructure.EntitiesConfiguration;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Breed).HasMaxLength(200).IsRequired();

        builder.Property(p => p.Gender).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Weight).HasPrecision(10, 2);
        builder.Property(p => p.Age);
        builder.Property(p => p.Address);




        builder.HasOne(e => e.PetOwner).WithMany(e => e.Pets)
            .HasForeignKey(e => e.PetOwnerId);
    }
}
