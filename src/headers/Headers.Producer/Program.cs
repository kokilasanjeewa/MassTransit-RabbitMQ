using MassTransit;
using Contracts;

var host = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost";
var user = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest";
var pass = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest";
var vhost = Environment.GetEnvironmentVariable("RABBITMQ_VHOST") ?? "/";

var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host(host, vhost, h => { h.Username(user); h.Password(pass); });
    cfg.Publish<IOrderMessage>(x =>
    {
        x.ExchangeType = "headers";
        x.ExchangeName = "ex.headers.order";
    });
});

await bus.StartAsync();
Console.WriteLine("[Headers Producer] Started");

var samples = new[]
{
    (country: "USA", priority: "high", product: "Phone"),
    (country: "USA", priority: "low", product: "Case"),
    (country: "UK", priority: "high", product: "Charger"),
};

foreach (var s in samples)
{
    await bus.Publish<IOrderMessage>(new
    {
        OrderId = Guid.NewGuid().ToString("N"),
        Product = s.product,
        Category = "Electronics"
    }, ctx =>
    {
        ctx.Headers.Set("country", s.country);
        ctx.Headers.Set("priority", s.priority);
    });
    Console.WriteLine($"[Headers Producer] Published {s.product} {{{{country={s.country}, priority={s.priority}}}}}");
}

await Task.Delay(Timeout.Infinite);
