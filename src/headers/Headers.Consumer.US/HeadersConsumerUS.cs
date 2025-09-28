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
