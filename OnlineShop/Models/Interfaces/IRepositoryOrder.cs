using OnlineShop.Models.Enums;

namespace OnlineShop.Models.Interfaces;

public interface IRepositoryOrder
{

    public Order TryOrderById(Guid userId);
    public void SetOrder(Guid userId, Guid serviceId, ActionType action);
}