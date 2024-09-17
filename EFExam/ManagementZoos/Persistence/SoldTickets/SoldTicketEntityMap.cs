using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zoo.Entities;

namespace Zoo.Persistence.SoldTickets;

public class SoldTicketEntityMap:IEntityTypeConfiguration<SoldTicket>
{
    public void Configure(EntityTypeBuilder<SoldTicket> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).UseIdentityColumn();
        builder.Property(_ => _.TicketId).IsRequired();
    }
}