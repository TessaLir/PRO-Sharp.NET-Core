namespace OnlineShop.Models;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public OrderType Type { get; set; } = OrderType.IN_CART;
    public List<OrderPosition> BasketPositions { get; set; }
}