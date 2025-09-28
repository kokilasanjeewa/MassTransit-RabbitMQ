using Contracts;
using MassTransit;

public class OrderConsumer2 : IConsumer<IOrderMessage>
{
    public Task Consume(ConsumeContext<IOrderMessage> context)
    {
        Console.WriteLine($"[OrderConsumer2] {context.Message.OrderId} - {context.Message.Product}");
        return Task.CompletedTask;
    }
}
