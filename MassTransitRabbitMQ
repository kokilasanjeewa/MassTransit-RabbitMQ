# MassTransit + RabbitMQ: Direct, Fanout, Topic, Headers — **Separate Microservices + Docker Compose**

This repository contains **separate microservices** for each RabbitMQ exchange pattern and a **full Dockerized setup**. Run everything with a single command.

---

## 📁 Repository Structure

```
./
├─ docker-compose.yml
├─ src/
│  ├─ common/
│  │  └─ Contracts/
│  │     ├─ Contracts.csproj
│  │     └─ Messages.cs
│  ├─ direct/
│  │  ├─ Direct.Producer/
│  │  │  ├─ Direct.Producer.csproj
│  │  │  └─ Program.cs
│  │  └─ Direct.Consumer.A/
│  │     ├─ Direct.Consumer.A.csproj
│  │     ├─ Program.cs
│  │     └─ OrderConsumer.cs
│  ├─ fanout/
│  │  ├─ Fanout.Producer/
│  │  │  ├─ Fanout.Producer.csproj
│  │  │  └─ Program.cs
│  │  ├─ Fanout.Consumer.1/
│  │  │  ├─ Fanout.Consumer.1.csproj
│  │  │  ├─ Program.cs
│  │  │  └─ OrderConsumer1.cs
│  │  └─ Fanout.Consumer.2/
│  │     ├─ Fanout.Consumer.2.csproj
│  │     ├─ Program.cs
│  │     └─ OrderConsumer2.cs
│  ├─ topic/
│  │  ├─ Topic.Producer/
│  │  │  ├─ Topic.Producer.csproj
│  │  │  └─ Program.cs
│  │  ├─ Topic.Consumer.Tech/
│  │  │  ├─ Topic.Consumer.Tech.csproj
│  │  │  ├─ Program.cs
│  │  │  └─ StockConsumerTech.cs
│  │  └─ Topic.Consumer.Finance/
│  │     ├─ Topic.Consumer.Finance.csproj
│  │     ├─ Program.cs
│  │     └─ StockConsumerFinance.cs
│  └─ headers/
│     ├─ Headers.Producer/
│     │  ├─ Headers.Producer.csproj
│     │  └─ Program.cs
│     ├─ Headers.Consumer.US/
│     │  ├─ Headers.Consumer.US.csproj
│     │  ├─ Program.cs
│     │  └─ HeadersConsumerUS.cs
│     └─ Headers.Consumer.AnyPriority/
│        ├─ Headers.Consumer.AnyPriority.csproj
│        ├─ Program.cs
│        └─ HeadersConsumerAny.cs
└─ README.md
```

> All apps are .NET 8 minimal Console apps using **MassTransit** with the **RabbitMQ** transport. Each service is self-contained and references `src/common/Contracts` for message contracts.

---

## 🐳 docker-compose.yml

```yaml
version: "3.9"

services:
  rabbitmq:
    image: rabbitmq:3.13-management
    container_name: rabbitmq
    ports:
      - "5672:5672"
      - "15672:15672" # management UI
    environment:
      RABBITMQ_DEFAULT_USER: guest
      RABBITMQ_DEFAULT_PASS: guest
    networks: [ demo-net ]

  # ------------------- DIRECT -------------------
  direct.producer:
    build: { context: ., dockerfile: src/direct/Direct.Producer/Dockerfile }
    depends_on: [ rabbitmq ]
    environment:
      RABBITMQ_HOST: rabbitmq
      RABBITMQ_USERNAME: guest
      RABBITMQ_PASSWORD: guest
      RABBITMQ_VHOST: /
    networks: [ demo-net ]

  direct.consumer.a:
    build: { context: ., dockerfile: src/direct/Direct.Consumer.A/Dockerfile }
    depends_on: [ rabbitmq ]
    environment:
      RABBITMQ_HOST: rabbitmq
      RABBITMQ_USERNAME: guest
      RABBITMQ_PASSWORD: guest
      RABBITMQ_VHOST: /
    networks: [ demo-net ]

  # ------------------- FANOUT -------------------
  fanout.producer:
    build: { context: ., dockerfile: src/fanout/Fanout.Producer/Dockerfile }
    depends_on: [ rabbitmq ]
    environment:
      RABBITMQ_HOST: rabbitmq
      RABBITMQ_USERNAME: guest
      RABBITMQ_PASSWORD: guest
      RABBITMQ_VHOST: /
    networks: [ demo-net ]

  fanout.consumer.1:
    build: { context: ., dockerfile: src/fanout/Fanout.Consumer.1/Dockerfile }
    depends_on: [ rabbitmq ]
    environment:
      RABBITMQ_HOST: rabbitmq
      RABBITMQ_USERNAME: guest
      RABBITMQ_PASSWORD: guest
      RABBITMQ_VHOST: /
    networks: [ demo-net ]

  fanout.consumer.2:
    build: { context: ., dockerfile: src/fanout/Fanout.Consumer.2/Dockerfile }
    depends_on: [ rabbitmq ]
    environment:
      RABBITMQ_HOST: rabbitmq
      RABBITMQ_USERNAME: guest
      RABBITMQ_PASSWORD: guest
      RABBITMQ_VHOST: /
    networks: [ demo-net ]

  # ------------------- TOPIC -------------------
  topic.producer:
    build: { context: ., dockerfile: src/topic/Topic.Producer/Dockerfile }
    depends_on: [ rabbitmq ]
    environment:
      RABBITMQ_HOST: rabbitmq
      RABBITMQ_USERNAME: guest
      RABBITMQ_PASSWORD: guest
      RABBITMQ_VHOST: /
    networks: [ demo-net ]

  topic.consumer.tech:
    build: { context: ., dockerfile: src/topic/Topic.Consumer.Tech/Dockerfile }
    depends_on: [ rabbitmq ]
    environment:
      RABBITMQ_HOST: rabbitmq
      RABBITMQ_USERNAME: guest
      RABBITMQ_PASSWORD: guest
      RABBITMQ_VHOST: /
    networks: [ demo-net ]

  topic.consumer.finance:
    build: { context: ., dockerfile: src/topic/Topic.Consumer.Finance/Dockerfile }
    depends_on: [ rabbitmq ]
    environment:
      RABBITMQ_HOST: rabbitmq
      RABBITMQ_USERNAME: guest
      RABBITMQ_PASSWORD: guest
      RABBITMQ_VHOST: /
    networks: [ demo-net ]

  # ------------------- HEADERS -------------------
  headers.producer:
    build: { context: ., dockerfile: src/headers/Headers.Producer/Dockerfile }
    depends_on: [ rabbitmq ]
    environment:
      RABBITMQ_HOST: rabbitmq
      RABBITMQ_USERNAME: guest
      RABBITMQ_PASSWORD: guest
      RABBITMQ_VHOST: /
    networks: [ demo-net ]

  headers.consumer.us:
    build: { context: ., dockerfile: src/headers/Headers.Consumer.US/Dockerfile }
    depends_on: [ rabbitmq ]
    environment:
      RABBITMQ_HOST: rabbitmq
      RABBITMQ_USERNAME: guest
      RABBITMQ_PASSWORD: guest
      RABBITMQ_VHOST: /
    networks: [ demo-net ]

  headers.consumer.any:
    build: { context: ., dockerfile: src/headers/Headers.Consumer.AnyPriority/Dockerfile }
    depends_on: [ rabbitmq ]
    environment:
      RABBITMQ_HOST: rabbitmq
      RABBITMQ_USERNAME: guest
      RABBITMQ_PASSWORD: guest
      RABBITMQ_VHOST: /
    networks: [ demo-net ]

networks:
  demo-net: {}
```

---

## 🔗 Common Contracts (`src/common/Contracts/Messages.cs`)

```csharp
namespace Contracts;

public interface IOrderMessage
{
    string OrderId { get; }
    string Product { get; }
    string Category { get; }
}

public interface IStockMessage
{
    string Symbol { get; }
    decimal Price { get; }
}
```

**`Contracts.csproj`**

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
</Project>
```

---

## 🧱 Base Dockerfile template (used by all services)

Create a `Dockerfile` in each service folder with this content (change `PROJECT_NAME` accordingly):

```dockerfile
# src/<area>/<ProjectName>/Dockerfile

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything so cross-project references restore/build
COPY . .

# Restore & publish only this project
RUN dotnet restore ./src/<area>/<ProjectName>/<ProjectName>.csproj
RUN dotnet publish ./src/<area>/<ProjectName>/<ProjectName>.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "<ProjectName>.dll"]
```

> Replace `<area>` and `<ProjectName>` per service.

Each `.csproj` should reference the common contracts:

```xml
<ItemGroup>
  <ProjectReference Include="../../common/Contracts/Contracts.csproj" />
</ItemGroup>
```

And include NuGets:

```xml
<ItemGroup>
  <PackageReference Include="MassTransit" Version="8.*" />
  <PackageReference Include="MassTransit.RabbitMQ" Version="8.*" />
</ItemGroup>
```

---

# 🔹 DIRECT Exchange

### Producer: `src/direct/Direct.Producer/Program.cs`

```csharp
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

    // Publish order messages via a DIRECT exchange
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
        // Routing key directs to a specific bound queue
        ctx.SetRoutingKey("direct.order.queue.a");
    });
    Console.WriteLine($"[Direct Producer] Published #{i}");
    await Task.Delay(1000);
}

await Task.Delay(Timeout.Infinite);
```

### Consumer A: `src/direct/Direct.Consumer.A/OrderConsumer.cs`

```csharp
using Contracts;
using MassTransit;

public class OrderConsumer : IConsumer<IOrderMessage>
{
    public Task Consume(ConsumeContext<IOrderMessage> context)
    {
        Console.WriteLine($"[Direct Consumer A] {context.Message.OrderId} - {context.Message.Product}");
        return Task.CompletedTask;
    }
}
```

**`src/direct/Direct.Consumer.A/Program.cs`**

```csharp
using MassTransit;
using Contracts;

var host = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost";
var user = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest";
var pass = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest";
var vhost = Environment.GetEnvironmentVariable("RABBITMQ_VHOST") ?? "/";

var builder = Host.CreateDefaultBuilder(args)
    .UseConsoleLifetime()
    .ConfigureServices((_, services) =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<OrderConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(host, vhost, h =>
                {
                    h.Username(user);
                    h.Password(pass);
                });

                cfg.ReceiveEndpoint("direct.order.queue.a", e =>
                {
                    // Bind to DIRECT exchange with routing key matching this queue
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
    .Build();

await builder.RunAsync();
```

---

# 🔹 FANOUT Exchange

### Producer: `src/fanout/Fanout.Producer/Program.cs`

```csharp
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
```

### Consumer 1: `src/fanout/Fanout.Consumer.1/OrderConsumer1.cs`

```csharp
using Contracts;
using MassTransit;

public class OrderConsumer1 : IConsumer<IOrderMessage>
{
    public Task Consume(ConsumeContext<IOrderMessage> context)
    {
        Console.WriteLine($"[Fanout Consumer 1] {context.Message.OrderId} - {context.Message.Product}");
        return Task.CompletedTask;
    }
}
```

**`Program.cs`**

```csharp
using MassTransit;
using Contracts;

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
```

### Consumer 2: `src/fanout/Fanout.Consumer.2/OrderConsumer2.cs`

```csharp
using Contracts;
using MassTransit;

public class OrderConsumer2 : IConsumer<IOrderMessage>
{
    public Task Consume(ConsumeContext<IOrderMessage> context)
    {
        Console.WriteLine($"[Fanout Consumer 2] {context.Message.OrderId} - {context.Message.Product}");
        return Task.CompletedTask;
    }
}
```

**`Program.cs`**

```csharp
using MassTransit;
using Contracts;

var host = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost";
var user = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest";
var pass = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest";
var vhost = Environment.GetEnvironmentVariable("RABBITMQ_VHOST") ?? "/";

await Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<OrderConsumer2>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(host, vhost, h => { h.Username(user); h.Password(pass); });
                cfg.ReceiveEndpoint("fanout.order.q2", e =>
                {
                    e.Bind("ex.fanout.order", x => x.ExchangeType = "fanout");
                    e.ConfigureConsumer<OrderConsumer2>(context);
                });
            });
        });
    })
    .RunConsoleAsync();
```

---

# 🔹 TOPIC Exchange

### Producer: `src/topic/Topic.Producer/Program.cs`

```csharp
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
```

### Consumer (Tech): `src/topic/Topic.Consumer.Tech/StockConsumerTech.cs`

```csharp
using Contracts;
using MassTransit;

public class StockConsumerTech : IConsumer<IStockMessage>
{
    public Task Consume(ConsumeContext<IStockMessage> context)
    {
        Console.WriteLine($"[Topic Tech] {context.Message.Symbol} @ {context.Message.Price}");
        return Task.CompletedTask;
    }
}
```

**`Program.cs`**

```csharp
using MassTransit;
using Contracts;

var host = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost";
var user = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest";
var pass = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest";
var vhost = Environment.GetEnvironmentVariable("RABBITMQ_VHOST") ?? "/";

await Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<StockConsumerTech>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(host, vhost, h => { h.Username(user); h.Password(pass); });
                cfg.ReceiveEndpoint("topic.stock.tech", e =>
                {
                    e.Bind("ex.topic.stock", x =>
                    {
                        x.ExchangeType = "topic";
                        x.RoutingKey = "tech.*";
                    });
                    e.ConfigureConsumer<StockConsumerTech>(context);
                });
            });
        });
    })
    .RunConsoleAsync();
```

### Consumer (Finance): `src/topic/Topic.Consumer.Finance/StockConsumerFinance.cs`

```csharp
using Contracts;
using MassTransit;

public class StockConsumerFinance : IConsumer<IStockMessage>
{
    public Task Consume(ConsumeContext<IStockMessage> context)
    {
        Console.WriteLine($"[Topic Finance] {context.Message.Symbol} @ {context.Message.Price}");
        return Task.CompletedTask;
    }
}
```

**`Program.cs`**

```csharp
using MassTransit;
using Contracts;

var host = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost";
var user = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest";
var pass = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest";
var vhost = Environment.GetEnvironmentVariable("RABBITMQ_VHOST") ?? "/";

await Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<StockConsumerFinance>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(host, vhost, h => { h.Username(user); h.Password(pass); });
                cfg.ReceiveEndpoint("topic.stock.finance", e =>
                {
                    e.Bind("ex.topic.stock", x =>
                    {
                        x.ExchangeType = "topic";
                        x.RoutingKey = "finance.*";
                    });
                    e.ConfigureConsumer<StockConsumerFinance>(context);
                });
            });
        });
    })
    .RunConsoleAsync();
```

---

# 🔹 HEADERS Exchange

### Producer: `src/headers/Headers.Producer/Program.cs`

```csharp
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

// Send different combinations of headers
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
```

### Consumer (US, ALL match): `src/headers/Headers.Consumer.US/HeadersConsumerUS.cs`

```csharp
using Contracts;
using MassTransit;

public class HeadersConsumerUS : IConsumer<IOrderMessage>
{
    public Task Consume(ConsumeContext<IOrderMessage> context)
    {
        Console.WriteLine($"[Headers US/ALL] {context.Message.OrderId} - {context.Message.Product}");
        return Task.CompletedTask;
    }
}
```

**`Program.cs`**

```csharp
using MassTransit;
using Contracts;

var host = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost";
var user = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest";
var pass = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest";
var vhost = Environment.GetEnvironmentVariable("RABBITMQ_VHOST") ?? "/";

await Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<HeadersConsumerUS>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(host, vhost, h => { h.Username(user); h.Password(pass); });
                cfg.ReceiveEndpoint("headers.order.us.all", e =>
                {
                    e.Bind("ex.headers.order", x =>
                    {
                        x.ExchangeType = "headers";
                        x.SetBindingArgument("country", "USA");
                        x.SetBindingArgument("priority", "high");
                        x.SetBindingArgument("x-match", "all");
                    });
                    e.ConfigureConsumer<HeadersConsumerUS>(context);
                });
            });
        });
    })
    .RunConsoleAsync();
```

### Consumer (ANY priority=high): `src/headers/Headers.Consumer.AnyPriority/HeadersConsumerAny.cs`

```csharp
using Contracts;
using MassTransit;

public class HeadersConsumerAny : IConsumer<IOrderMessage>
{
    public Task Consume(ConsumeContext<IOrderMessage> context)
    {
        Console.WriteLine($"[Headers ANY/priority=high] {context.Message.OrderId} - {context.Message.Product}");
        return Task.CompletedTask;
    }
}
```

**`Program.cs`**

```csharp
using MassTransit;
using Contracts;

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
```

---

## 🧩 Sample `.csproj` for a service (e.g., `Direct.Producer.csproj`)

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="MassTransit" Version="8.*" />
    <PackageReference Include="MassTransit.RabbitMQ" Version="8.*" />
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="../../common/Contracts/Contracts.csproj" />
  </ItemGroup>
</Project>
```

---

## ▶️ How to Run

1. Ensure Docker is running.
2. From the repo root, run:

   ```bash
   docker compose up --build
   ```
3. Open RabbitMQ Management UI at **[http://localhost:15672](http://localhost:15672)** (guest/guest) to see exchanges, queues, and bindings:

   * `ex.direct.order`, `ex.fanout.order`, `ex.topic.stock`, `ex.headers.order`
   * Queues like `direct.order.queue.a`, `fanout.order.q1`, etc.

> Logs in the compose output will show which consumers receive which messages.

---

## ✅ Notes & Tips

* MassTransit automatically manages exchanges/queues when you call `e.Bind(...)` and configure `cfg.Publish<...>(...)`.
* For **Direct**, the routing key determines which queue receives the message.
* For **Fanout**, all bound queues receive every message.
* For **Topic**, keys like `tech.apple` match bindings like `tech.*`.
* For **Headers**, bindings match on header key/value pairs with `x-match` of `all` or `any`.
* To experiment, change routing keys or headers in the producers and observe which consumers receive messages.

---

## 🧪 Health/Resilience (optional hardening)

* Add `cfg.ConfigureEndpoints(context);` if you switch to MT endpoint conventions.
* Configure retry:

  ```csharp
  cfg.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(2)));
  ```
* Add outbox/inbox if you persist to a DB.

---

## 📌 Next steps

* Want me to package this as a GitHub-ready zip with full `.csproj` files and Dockerfiles pre-filled? I can generate those too.
