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
            x.AddConsumer<HeadersConsumerAny>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(host, vhost, h => { h.Username(user); h.Password(pass); });
                cfg.ReceiveEndpoint("headers.order.any.high", e =>
                {
                    e.Bind("ex.headers.order", x =>
                    {
                        x.ExchangeType = "headers";
                        x.SetBindingArgument("priority", "high");
                        x.SetBindingArgument("x-match", "any");
                    });
                    e.ConfigureConsumer<HeadersConsumerAny>(context);
                });
            });
        });
    })
    .RunConsoleAsync();
