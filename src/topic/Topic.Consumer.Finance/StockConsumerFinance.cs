using Contracts;
using MassTransit;

public class StockConsumerFinance : IConsumer<IStockMessage>
{
    public Task Consume(ConsumeContext<IStockMessage> context)
    {
        Console.WriteLine($"[StockConsumerFinance] {context.Message.Symbol} @ {context.Message.Price}");
        return Task.CompletedTask;
    }
}
