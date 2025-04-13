using OnlineShop.Models.Enums;

namespace OnlineShop.Models.Interfaces;

public interface IRepository
{
    public Guid GetUserId();
    
    public List<Service> GetServicesList();
    public Service? TryServiceById(Guid? id);

    public Basket TryBasketById(Guid userId);
    public void SetBasket(Guid userId, Guid serviceId, ActionType action);
}