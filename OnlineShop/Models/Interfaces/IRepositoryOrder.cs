using OnlineShop.Models.Enums;

namespace OnlineShop.Models.Interfaces;

public interface IRepositoryOrder
{
    public Order TryOrderById(Guid userId, OrderType? type);
    public void SetOrder(Guid userId, ActionType action, Guid? serviceId);
}