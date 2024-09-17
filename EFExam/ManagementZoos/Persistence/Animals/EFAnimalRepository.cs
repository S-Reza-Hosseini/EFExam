using Zoo.Dtos.Animals;
using Zoo.Entities;

namespace Zoo.Persistence.Animals;

public class EFAnimalRepository(EFDataContext context)
{
    public void AddAnimal(Animal animal)
    {
        context.Set<Animal>().Add(animal);
    }

    public void DeleteAnimal(Animal animal)
    {
        context.Set<Animal>().Remove(animal);
    }

    public Animal GetAnimalById(int animalId)
    {
        return context.Animals.FirstOrDefault(_ => _.Id == animalId);
    }

    public List<ShowAnimalDto> GetAllAnimalDto()
    {
        return (
            from animal in context.Set<Animal>()
            select new ShowAnimalDto()
            {
                Id = animal.Id,
                Name = animal.Name,
                PartId = animal.Id
            }
        ).ToList();
    }
}