using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zoo.Persistence.Zoos;

public class ZooEntityMap:IEntityTypeConfiguration<Entities.Zoo>
{
    public void Configure(EntityTypeBuilder<Entities.Zoo> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).UseIdentityColumn();
        builder.Property(_ => _.Name).HasMaxLength(100).IsRequired();
        builder.Property(_ => _.Address).HasMaxLength(500).IsRequired();
        
    }
}