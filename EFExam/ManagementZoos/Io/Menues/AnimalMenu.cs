using residential_complex.Io.Interfaces;
using Zoo.Entities;
using Zoo.Persistence;
using Zoo.Persistence.Animals;

namespace residential_complex.Io.Menues;

public class AnimalMenu(EFDataContext context, IUi io) : MenuStructure(io)
{
    private readonly EFAnimalRepository _animalRepository = new EFAnimalRepository(context);
    protected override string ExitMessageMenu { get; } = "Back to main Menu";

    protected override void AddMenuItems()
    {
        MenuItems.Add("Add Animal", AddAnimal);
        MenuItems.Add("ShowAll Animal", ShowAll);
        MenuItems.Add("Delete Animal", DeleteAnimal);
        MenuItems.Add("Update Animal", UpdateAnimal);
        
    }
    public void AddAnimal()
    {
        var cost = new Animal()
        {
            Name = io.GetStringFromUser("Name for cost"),
            PartId = io.GetIntegerFromUser("Part id "),
        };
        _animalRepository.AddAnimal(cost);
        context.SaveChanges();
    }

    public void DeleteAnimal()
    {
        ShowAll();
        var animalId = io.GetIntegerFromUser("animal id");
        var animal = _animalRepository.GetAnimalById(animalId);
        _animalRepository.DeleteAnimal(animal);
        context.SaveChanges();
        io.ShowMessage("done!!");
    }

    public void ShowAll()
    {
        var animals = _animalRepository.GetAllAnimalDto();
        foreach (var animal in animals)
        {
            io.ShowMessage($"{animal.Id} - {animal.Name} -  Address :{animal.PartId}");
        }
    }

    public void UpdateAnimal()
    {
        ShowAll();
        var animalId = io.GetIntegerFromUser("animal id");
        var animal = _animalRepository.GetAnimalById(animalId);

        animal.Name = io.GetStringFromUser("animal name");
        context.SaveChanges();
    }
    
}