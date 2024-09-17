using Zoo.Entities;

namespace Zoo.Dtos.Zoos;

public class ShowZooWithAnimalsDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<String> AnimalsName { get; set; }
}