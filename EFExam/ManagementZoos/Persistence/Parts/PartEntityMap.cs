using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zoo.Entities;

namespace Zoo.Persistence.Parts;

public class PartEntityMap:IEntityTypeConfiguration<Part>
{
    public void Configure(EntityTypeBuilder<Part> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).UseIdentityColumn();
        builder.Property(_ => _.Description).IsRequired(false).HasMaxLength(500);
        builder.Property(_ => _.Area).IsRequired();
        builder.HasOne(_ => _.Zoo).WithMany(_ => _.Parts).HasForeignKey(_ => _.ZooId);
        
        builder.HasOne(_ => _.Animal)
            .WithMany(_ => _.AParts)
            .HasForeignKey(_ => _.AnimalId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}