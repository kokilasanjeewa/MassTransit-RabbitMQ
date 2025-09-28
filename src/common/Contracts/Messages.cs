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
