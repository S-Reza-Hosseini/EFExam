using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Zoo.Dtos.Parts;

public class ShowPartAndTyeAndCountAnimalsDto
{
    public int Id { get; set; }
    public string AnimalName { get; set; }
    public int CountAnimal { get; set; }
    public string Describtion { get; set; }
}