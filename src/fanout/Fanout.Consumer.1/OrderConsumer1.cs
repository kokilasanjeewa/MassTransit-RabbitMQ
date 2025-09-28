using Contracts;
using MassTransit;

public class OrderConsumer1 : IConsumer<IOrderMessage>
{
    public Task Consume(ConsumeContext<IOrderMessage> context)
    {
        Console.WriteLine($"[OrderConsumer1] {context.Message.OrderId} - {context.Message.Product}");
        return Task.CompletedTask;
    }
}
