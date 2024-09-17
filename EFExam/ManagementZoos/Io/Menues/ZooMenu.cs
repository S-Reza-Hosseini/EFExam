using residential_complex.Exceptions;
using residential_complex.Io.Interfaces;
using Zoo.Persistence;
using Zoo.Persistence.Zoos;

namespace residential_complex.Io.Menues;

public class ZooMenu(EFDataContext context, IUi io) : MenuStructure(io)
{
    private readonly EFZooRepository _zooPartRepository = new EFZooRepository(context);
    protected override string ExitMessageMenu { get; } = "Back to main Menu";

    protected override void AddMenuItems()
    {
        MenuItems.Add("Add Zoo", AddZoo);
        MenuItems.Add("ShowAll Zoo", ShowAll);
        MenuItems.Add("Delete Zoo", DeleteZoo);
        MenuItems.Add("Show Zoo with animals", ShowZooWithAnimals);
        MenuItems.Add("Show zoo Part With Price And Area", ShowZooAndPartWithPriceAndArea);
        MenuItems.Add("Update zoo", UpdateAnimal);
        
    }
    public void AddZoo()
    {
        var cost = new Zoo.Entities.Zoo()
        {
            Name = io.GetStringFromUser("Name for cost"),
            Address = io.GetStringFromUser("Address for Zoo "),
        };
        _zooPartRepository.AddZoo(cost);
        context.SaveChanges();
    }

    public void DeleteZoo()
    {
        ShowAll();
        var zooPartId = io.GetIntegerFromUser("zooPart id");
        var zooPart = _zooPartRepository.GetZooById(zooPartId);
        context.SaveChanges();
        io.ShowMessage("done!!");
    }

    public void ShowAll()
    {
        var zooParts = _zooPartRepository.GetAllZooDto();
        foreach (var zooPart in zooParts)
        {
            io.ShowMessage($"{zooPart.Id} - {zooPart.Name} -  Address :{zooPart.Address}");
        }
    }

    public void ShowZooWithAnimals()
    {
        var zooPartWithAnimals = _zooPartRepository.GetZooWithAnimalsDto();
        foreach (var zooPart in zooPartWithAnimals)
        {
            io.ShowMessage($"{zooPart.Id} - {zooPart.Name} - " +
                           $"Address :{zooPart.Address} - ");
            
            for (int i = 0; i < zooPart.AnimalsName.Count ; i++)
            {
                io.ShowMessage($"{zooPart.AnimalsName[i]}");
            }
        }
    }

    public void ShowZooAndPartWithPriceAndArea()
    {
        var zooParts = 
            _zooPartRepository.GetZooAndpartWithPriceAndAreaDtos();
        foreach (var zooPart in zooParts)
        {
            io.ShowMessage($"{zooPart.Id} - count part zooPart :{zooPart.CountPart} " +
                           $"- Area Part:{zooPart.Area} - " +
                           $"Price part{zooPart.Price}");
        }
    }
    public void UpdateAnimal()
    {
        ShowAll();
        var zooId = io.GetIntegerFromUser("Zoo id");
        var zoo = _zooPartRepository.GetZooById(zooId);

        zoo.Name = io.GetStringFromUser("animal name");
        zoo.Address = io.GetStringFromUser("zoo address");
        context.SaveChanges();
    }
}