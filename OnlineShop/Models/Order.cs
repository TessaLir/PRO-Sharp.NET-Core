namespace OnlineShop.Models;

public class Order
{
    public Guid UserId { get; set; }
    public List<OrderPosition> BasketPositions { get; set; }
}