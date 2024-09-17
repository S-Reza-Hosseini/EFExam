using Microsoft.EntityFrameworkCore;
using Zoo.Dtos.Zoos;
using Zoo.Entities;

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

    public List<ShowZooWithAnimalsDto> GetZooWithAnimalsDto()
    {
        return context.Zoos.Include(_ => _.Parts).Select(_ => new ShowZooWithAnimalsDto()
        {
            Id = _.Id,
            Name = _.Name,
            Address = _.Address,
            AnimalsName = _.Parts.Select(p => p.Animal.Name).ToList(),
        }).ToList();
    }

    public List<ShowZooAndpartWithPriceAndAreaDto> GetZooAndpartWithPriceAndAreaDtos()
    {
        return context.Zoos.Include(_=>_.Parts).Select(_ => new ShowZooAndpartWithPriceAndAreaDto()
        {
            Id = _.Id,
            CountPart = _.Parts.Count,
            Price = _.Parts.Select(_ => _.Ticket.Price).FirstOrDefault(),
            Area = _.Parts.Select(_ => _.Area).FirstOrDefault()
            
        }).ToList();
    }
    
    
}