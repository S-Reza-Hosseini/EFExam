namespace Zoo.Entities;

public class Ticket
{
    public int Id { get; set; }
    public Part Part { get; set; }
    public int PartId { get; set; }
    public decimal Price { get; set; }
}