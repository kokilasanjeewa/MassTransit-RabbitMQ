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
            x.AddConsumer<OrderConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(host, vhost, h => { h.Username(user); h.Password(pass); });

                cfg.ReceiveEndpoint("direct.order.queue.a", e =>
                {
                    e.Bind("ex.direct.order", x =>
                    {
                        x.ExchangeType = "direct";
                        x.RoutingKey = "direct.order.queue.a";
                    });

                    e.ConfigureConsumer<OrderConsumer>(context);
                });
            });
        });
    })
    .RunConsoleAsync();
