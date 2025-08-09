using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Registrar MassTransit com RabbitMQ
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    });
});

// Registrar controllers
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

// Endpoint raiz simples para teste da API
app.MapGet("/", () => "ProductService rodando!");

app.Run("http://0.0.0.0:8080");

