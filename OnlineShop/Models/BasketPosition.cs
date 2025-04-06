namespace OnlineShop.Models;

public class BasketPosition
{
    public Service Service { get; set; }
    public int Count { get; set; }
    public double Cost { get; set; }
}