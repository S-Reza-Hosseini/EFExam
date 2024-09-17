using residential_complex.Io.Interfaces;
using Zoo.Entities;
using Zoo.Persistence;
using Zoo.Persistence.Tickets;

namespace residential_complex.Io.Menues;

public class TicketMenu(EFDataContext context, IUi io):MenuStructure(io)
{
    private readonly EFTicketRepository _ticketRepository = new EFTicketRepository(context);
    ZooMenu zoo = new ZooMenu(context, io);
    PartMenu part = new PartMenu(context, io);
    protected override string ExitMessageMenu { get; } = "Back to main Menu";
    protected override void AddMenuItems()
    {
        MenuItems.Add("Add Ticket", AddTicket);
        MenuItems.Add("ShowAll", ShowAll);
        MenuItems.Add("Delete Ticket", DeleteTicket);
        MenuItems.Add("Update part", UpdatePart);
        
    }
    public void AddTicket()
    {
        zoo.ShowAll();
        var zooId = io.GetIntegerFromUser("zoo id");
     
        part.ShowAll();
        var ticketId = io.GetIntegerFromUser("zoo id");

        
        var ticket = new Ticket()
        {
            PartId = ticketId,
            Price = io.GetDecimalFromUser("Ticket price"),
        };
        _ticketRepository.AddTicket(ticket);
        context.SaveChanges();
    }

    public void DeleteTicket()
    {
        ShowAll();
        var ticketId = io.GetIntegerFromUser("ticket id");
        var ticket = _ticketRepository.GetTicketById(ticketId);
        _ticketRepository.DeleteTicket(ticket);
        context.SaveChanges();
        io.ShowMessage("done!!");
    }

    public void ShowAll()
    {
        var tickets = _ticketRepository.GetAllTicketDto();
        foreach (var ticket in tickets)
        {
            io.ShowMessage($"{ticket.Id} - part :{ticket.PartName} - price :{ticket.Price} ");
        }
    }

    public void UpdatePart()
    {
        ShowAll();
        var ticketId = io.GetIntegerFromUser("ticket id");
        var ticket = _ticketRepository.GetTicketById(ticketId);

        ticket.Price = io.GetDecimalFromUser("new price");
      
        context.SaveChanges();
    }
}