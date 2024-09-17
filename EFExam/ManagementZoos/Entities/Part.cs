namespace Zoo.Entities;

public class Part
{
    public int Id { get; set; }

    public string? Description { get; set; }
    public Double Area { get; set; }
    public Animal? Animal { get; set; }
    public int? AnimalId { get; set; }
    public Zoo Zoo { get; set; }
    public int ZooId { get; set; }
    public int CountAnimal { get; set; }

    public Ticket Ticket { get; set; }
    public int TicketId { get; set; }
}