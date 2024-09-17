using residential_complex.Io.Interfaces;
using Zoo.Entities;
using Zoo.Persistence;
using Zoo.Persistence.Parts;
using Zoo.Persistence.Zoos;

namespace residential_complex.Io.Menues;

public class PartMenu(EFDataContext context, IUi io) : MenuStructure(io)
{
    private readonly EFPartRepository _efPartRepository = new EFPartRepository(context);
    ZooMenu zoo = new ZooMenu(context, io);
    protected override string ExitMessageMenu { get; } = "Back to main Menu";
    protected override void AddMenuItems()
    {
        MenuItems.Add("Add Part", AddPart);
        MenuItems.Add("ShowAll part", ShowAll);
        MenuItems.Add("Delete part", DeletePart);
        MenuItems.Add("Update part", UpdatePart);
        
    }
    public void AddPart()
    {
        zoo.ShowAll();
        var zooId = io.GetIntegerFromUser("zoo id");
        
        
        var part = new Part()
        {
            ZooId = zooId,
            Description = io.GetStringFromUser("Description"),
            Area = io.GetDoubleFromUser("area part"),
            TicketId = io.GetIntegerFromUser("ticket id")
        };
        _efPartRepository.AddPart(part);
        context.SaveChanges();
    }

    public void DeletePart()
    {
        ShowAll();
        var partId = io.GetIntegerFromUser("part id");
        var part = _efPartRepository.GetPartById(partId);
        context.SaveChanges();
        io.ShowMessage("done!!");
    }

    public void ShowAll()
    {
        var animals = _efPartRepository.GetAllPartDto();
        foreach (var animal in animals)
        {
            io.ShowMessage($"{animal.Id} - {animal.Area} ");
        }
    }

    public void UpdatePart()
    {
        ShowAll();
        var partId = io.GetIntegerFromUser("animal id");
        var part = _efPartRepository.GetPartById(partId);

        part.Description = io.GetStringFromUser("part Description");
        part.Area = io.GetDoubleFromUser("part area");
        context.SaveChanges();
    }
    
    
}