namespace OnlineShop.Models;

public interface IRepositoryBasket
{

    public Basket TryBasketById(Guid userId);
    public void SetBasket(Guid userId, Guid serviceId, ActionType action);
}