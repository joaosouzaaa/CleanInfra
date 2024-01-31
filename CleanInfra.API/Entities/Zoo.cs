namespace CleanInfra.API.Entities;

public sealed class Zoo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public decimal EntryPrice { get; set; }

    public List<Animal> Animals { get; set; }
}
