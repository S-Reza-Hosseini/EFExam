
using residential_complex.Io.Interfaces;
using Zoo.Persistence;

namespace residential_complex.Io.Menues;

public class MainMenu(EFDataContext context, IUi io):MenuStructure(io)
{
    protected override void AddMenuItems()
    {
        MenuItems.Add("Show Zoo menu:", ShowZooMenu);
        MenuItems.Add("Show Ticket menu:", ShowTicketMenu);
        MenuItems.Add("Show Animal menu:", ShowAnimalMenu);
        MenuItems.Add("Show Part menu:", ShowPartMenu);
        MenuItems.Add("Show SoldTicketMenu menu:", ShowSoldTicketMenu);
    }

    private void ShowZooMenu()
    {
        new ZooMenu(context, io).Show();
    }

    private void ShowTicketMenu()
    {
        new TicketMenu(context, io).Show();
    }

    private void ShowAnimalMenu()
    {
        new AnimalMenu(context, io).Show();
    }

    private void ShowPartMenu()
    {
        new PartMenu(context, io).Show();
    }
    private void ShowSoldTicketMenu()
    {
        new SoldTicketMenu(context, io).Show();
    }
    
}