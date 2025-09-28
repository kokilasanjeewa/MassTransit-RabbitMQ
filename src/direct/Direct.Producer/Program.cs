using MassTransit;
using Contracts;

var host = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost";
var user = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest";
var pass = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest";
var vhost = Environment.GetEnvironmentVariable("RABBITMQ_VHOST") ?? "/";

var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host(host, vhost, h =>
    {
        h.Username(user);
        h.Password(pass);
    });

    cfg.Publish<IOrderMessage>(x =>
    {
        x.ExchangeType = "direct";
        x.ExchangeName = "ex.direct.order";
    });
});

await bus.StartAsync();
Console.WriteLine("[Direct Producer] Started");

for (var i = 1; i <= 5; i++)
{
    await bus.Publish<IOrderMessage>(new
    {
        OrderId = Guid.NewGuid().ToString("N"),
        Product = $"Item-{i}",
        Category = "General"
    }, ctx =>
    {
        ctx.SetRoutingKey("direct.order.queue.a");
    });
    Console.WriteLine($"[Direct Producer] Published #{i}");
    await Task.Delay(1000);
}

await Task.Delay(Timeout.Infinite);
