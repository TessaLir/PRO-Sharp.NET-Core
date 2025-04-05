namespace OnlineShop.Models;

public class Service
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Cost { get; set; }
    public string Description { get; set; }

    
    public override string ToString()
    {
        return $"{Id}\r\n{Name}\r\n{Cost}";
    }
}