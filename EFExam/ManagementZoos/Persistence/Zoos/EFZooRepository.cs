using Zoo.Dtos.Zoos;

namespace Zoo.Persistence.Zoos;

public class EFZooRepository(EFDataContext context)
{
    public void AddZoo(Entities.Zoo zoo)
    {
        context.Set<Entities.Zoo>().Add(zoo);
    }

    public void DeleteZoo(Entities.Zoo zoo)
    {
        context.Set<Entities.Zoo>().Remove(zoo);
    }

    public Entities.Zoo GetZooById(int zooId)
    {
        return context.Zoos.FirstOrDefault(_ => _.Id == zooId);
    }

    public List<ShowZooDto> GetAllZooDto()
    {
        return (
            from zoo in context.Set<Entities.Zoo>()
            select new ShowZooDto()
            {
                Id = zoo.Id,
                Name = zoo.Name,
                Address = zoo.Address
            }
        ).ToList();
    }
}