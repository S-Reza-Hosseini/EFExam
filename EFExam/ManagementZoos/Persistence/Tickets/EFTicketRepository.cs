using Zoo.Dtos.Tickets;
using Zoo.Entities;

namespace Zoo.Persistence.Tickets;

public class EFTicketRepository(EFDataContext context)
{
    public void AddTicket(Ticket ticket)
    {
        context.Set<Ticket>().Add(ticket);
    }

    public void DeleteTicket(Ticket ticket)
    {
        context.Set<Ticket>().Remove(ticket);
    }

    public Ticket GetTicketById(int ticketId)
    {
        return context.Tickets.FirstOrDefault(_ => _.Id == ticketId);
    }

    public List<ShowTicketDto> GetAllTicketDto()
    {
        return (
            from ticket in context.Set<Ticket>()
            select new ShowTicketDto()
            {
                Id = ticket.Id,
                PartName = ticket.Part.Animal.Name,
                Price = ticket.Price
            }
        ).ToList();
    }
}