using Zoo.Dtos.Parts;
using Zoo.Entities;

namespace Zoo.Persistence.Parts;

public class EFPartRepository(EFDataContext context)
{
    public void AddPart(Part part)
    {
        context.Set<Part>().Add(part);
    }

    public void DeletePart(Part part)
    {
        context.Set<Part>().Remove(part);
    }

    public Part GetPartById(int partId)
    {
        return context.Parts.FirstOrDefault(_ => _.Id == partId);
    }

    public List<ShowPartDto> GetAllPartDto()
    {
        return (
            from part in context.Set<Part>()
            select new ShowPartDto()
            {
                Id = part.Id,
                Description = part.Description,
                Area = part.Area,
                AnimalName = part.Animal.Name
            }
        ).ToList();
    }

    public List<ShowPartAndTyeAndCountAnimalsDto> GetPartAndTyeAndCountAnimalsDto()
    {
        return (
            from part in context.Parts
            select new ShowPartAndTyeAndCountAnimalsDto()
            {
                Id = part.Id,
                Describtion = part.Description,
                AnimalName = part.Animal.Name,
                CountAnimal = part.CountAnimal
            }).ToList();
    }
}