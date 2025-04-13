using OnlineShop.Models.Enums;

namespace OnlineShop.Models.Interfaces;

public interface IRepositoryBasket
{

    public Basket TryBasketById(Guid userId);
    public void SetBasket(Guid userId, Guid serviceId, ActionType action);
}