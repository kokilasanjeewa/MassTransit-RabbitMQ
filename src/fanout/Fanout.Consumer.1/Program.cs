using MassTransit;
using Contracts;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var host = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost";
var user = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest";
var pass = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest";
var vhost = Environment.GetEnvironmentVariable("RABBITMQ_VHOST") ?? "/";

await Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<OrderConsumer1>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(host, vhost, h => { h.Username(user); h.Password(pass); });
                cfg.ReceiveEndpoint("fanout.order.q1", e =>
                {
                    e.Bind("ex.fanout.order", x => x.ExchangeType = "fanout");
                    e.ConfigureConsumer<OrderConsumer1>(context);
                });
            });
        });
    })
    .RunConsoleAsync();
