using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zoo.Entities;

namespace Zoo.Persistence.Tickets;

public class TicketEntityMap:IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).UseIdentityColumn();
        builder.Property(_ => _.Price).IsRequired().HasColumnType("decimal(8,2)");
        builder.HasOne(_ => _.Part).WithOne(_ => _.Ticket).HasForeignKey<Part>(_ => _.TicketId);
        
    }
}