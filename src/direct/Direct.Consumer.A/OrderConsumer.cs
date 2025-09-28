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
