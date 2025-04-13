using OnlineShop.Models.Enums;

namespace OnlineShop.Models.Interfaces;

public interface IRepository
{
    public Guid GetUserId();
    
    public List<Service> GetServicesList();
    public Service? TryServiceById(Guid? id);

    public Order TryOrderById(Guid userId, OrderType? type);
    public void SetOrder(Guid userId, ActionType action, Guid? serviceId);
}