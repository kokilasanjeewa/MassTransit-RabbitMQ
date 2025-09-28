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
