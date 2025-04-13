using OnlineShop.Models.Enums;

namespace OnlineShop.Models.Interfaces;

public interface IRepository
{
    public Guid GetUserId();
    
    public List<Service> GetServicesList();
    public Service? TryServiceById(Guid? id);

    public Order TryOrderById(Guid userId);
    public void SetOrder(Guid userId, Guid serviceId, ActionType action);
}