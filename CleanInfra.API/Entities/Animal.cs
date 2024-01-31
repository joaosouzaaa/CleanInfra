namespace CleanInfra.API.Entities;

public sealed class Animal
{
    public int Id { get; set; }
    public required string ScientificName { get; set; }
    public required string Species { get; set; }

    public required int ZooId { get; set; }
    public Zoo Zoo { get; set; }
}
