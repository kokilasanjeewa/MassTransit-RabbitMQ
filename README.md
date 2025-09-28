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
* Want me to package this as a GitHub-ready zip with full `.csproj` files and Dockerfiles pre-filled? I can generate those too.
