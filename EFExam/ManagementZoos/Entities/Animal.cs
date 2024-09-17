namespace Zoo.Entities;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PartId { get; set; }
    public List<Part> AParts { get; set; } = [];
}