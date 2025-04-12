namespace OnlineShop.Models;

public class Basket
{
    public Guid UserId { get; set; }
    public List<BasketPosition> BasketPositions { get; set; }
}