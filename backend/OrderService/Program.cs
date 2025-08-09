using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ProductCreatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("product-created-queue", e =>
        {
            e.ConfigureConsumer<ProductCreatedConsumer>(context);
        });
    });
});

var app = builder.Build();

app.MapGet("/", () => "OrderService rodando!");

app.Run("http://0.0.0.0:8080");

// Consumer do evento ProductCreated
public class ProductCreatedConsumer : IConsumer<ProductCreated>
{
    public Task Consume(ConsumeContext<ProductCreated> context)
    {
        Console.WriteLine($"Evento recebido no OrderService: Produto {context.Message.Name} com preço {context.Message.Price}");
        return Task.CompletedTask;
    }
}

// Definição do evento (pode ser compartilhada em um projeto comum)
public record ProductCreated
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
}
