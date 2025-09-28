using Contracts;
using MassTransit;

public class StockConsumerTech : IConsumer<IStockMessage>
{
    public Task Consume(ConsumeContext<IStockMessage> context)
    {
        Console.WriteLine($"[StockConsumerTech] {context.Message.Symbol} @ {context.Message.Price}");
        return Task.CompletedTask;
    }
}
