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
        x.ExchangeType = "fanout";
        x.ExchangeName = "ex.fanout.order";
    });
});

await bus.StartAsync();
Console.WriteLine("[Fanout Producer] Started");

for (var i = 1; i <= 3; i++)
{
    await bus.Publish<IOrderMessage>(new
    {
        OrderId = Guid.NewGuid().ToString("N"),
        Product = $"Broadcast-{i}",
        Category = "Broadcast"
    });
    Console.WriteLine($"[Fanout Producer] Published #{i}");
}

await Task.Delay(Timeout.Infinite);
