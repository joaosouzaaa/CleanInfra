namespace CleanInfra.API.Entities;

public sealed class Zoo
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Location { get; set; }
    public required decimal EntryPrice { get; set; }

    public List<Animal> Animals { get; set; }
}
