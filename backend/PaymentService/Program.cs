using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<OrderCreatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("order-created-queue", e =>
        {
            e.ConfigureConsumer<OrderCreatedConsumer>(context);
        });
    });
});

var app = builder.Build();

app.MapGet("/", () => "PaymentService rodando!");

app.Run("http://0.0.0.0:8080");

public class OrderCreatedConsumer : IConsumer<OrderCreated>
{
    public Task Consume(ConsumeContext<OrderCreated> context)
    {
        Console.WriteLine($"Evento recebido no PaymentService: Pedido {context.Message.OrderId} no valor {context.Message.TotalAmount}");
        return Task.CompletedTask;
    }
}

public record OrderCreated
{
    public Guid OrderId { get; init; }
    public decimal TotalAmount { get; init; }
}
