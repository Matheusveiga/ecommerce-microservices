namespace ProductService.Models;

public record ProductCreated
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; init; } = default!;
    public decimal Price { get; init; }
}
