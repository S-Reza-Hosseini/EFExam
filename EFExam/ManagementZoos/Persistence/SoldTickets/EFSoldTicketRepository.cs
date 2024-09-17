using System.Text.RegularExpressions;
using Zoo.Dtos.SoldTickets;
using Zoo.Entities;

namespace Zoo.Persistence.SoldTickets;

public class EFSoldTicketRepository(EFDataContext context)
{
    public void AddSoldTicket(SoldTicket soldTicket)
    {
        context.Set<SoldTicket>().Add(soldTicket);
    }

    public void DeleteSoldTicket(SoldTicket soldTicket)
    {
        context.Set<SoldTicket>().Remove(soldTicket);
    }

    public SoldTicket GetSoldTicketById(int soldTicketId)
    {
        return context.Set<SoldTicket>().FirstOrDefault(_ => _.Id == soldTicketId);
    }

    public List<ShowSoldTicketDto> GetAllSoldTicketDto()
    {
        return (
            from soldTicket in context.Set<SoldTicket>()
            join ticket in context.Set<Ticket>()
                on soldTicket.TicketId equals ticket.Id
                into soldsTickets
            from soldsTicket in soldsTickets.DefaultIfEmpty()
            join part in context.Set<Part>()
                on soldTicket.TicketId equals part.TicketId
            select new ShowSoldTicketDto()
            {
                Id = soldTicket.Id,
                TicketDescription = part.Description != null? part.Description : "without Description"
            }
        ).ToList();
    }

    public List<ShowSoldTicketByCountSoldDto> GetSoldTicketByCountSoldDto()
    {
        return (from soldTicket in context.Set<SoldTicket>()
            join ticket in context.Set<Ticket>()
                on soldTicket.TicketId equals ticket.Id
                into soldsTickets
            group soldsTickets by soldTicket.Id into groupedSoldTickets
            select new ShowSoldTicketByCountSoldDto()
            {
                Id = groupedSoldTickets.Key,
                CountSold = groupedSoldTickets.Count()
            }
            ).OrderByDescending(g => g.CountSold).ToList();

    }
}