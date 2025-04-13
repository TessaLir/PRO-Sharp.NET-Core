namespace OnlineShop.Models;

public interface IRepositoryServices
{
    public List<Service> GetServicesList();
    public Service? TryServiceById(Guid? id);
}