using MassTransit;
using Contracts;

var host = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost";
var user = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest";
var pass = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest";
var vhost = Environment.GetEnvironmentVariable("RABBITMQ_VHOST") ?? "/";

var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host(host, vhost, h => { h.Username(user); h.Password(pass); });
    cfg.Publish<IStockMessage>(x =>
    {
        x.ExchangeType = "topic";
        x.ExchangeName = "ex.topic.stock";
    });
});

await bus.StartAsync();
Console.WriteLine("[Topic Producer] Started");

var msgs = new (string key, string symbol, decimal price)[]
{
    ("tech.apple", "AAPL", 230.12m),
    ("tech.microsoft", "MSFT", 415.55m),
    ("finance.banks", "JPM", 196.22m),
};

foreach (var (key, symbol, price) in msgs)
{
    await bus.Publish<IStockMessage>(new { Symbol = symbol, Price = price }, ctx => ctx.SetRoutingKey(key));
    Console.WriteLine($"[Topic Producer] Published {symbol} with key {key}");
}

await Task.Delay(Timeout.Infinite);
