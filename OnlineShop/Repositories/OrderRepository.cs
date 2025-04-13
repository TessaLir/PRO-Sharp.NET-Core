using OnlineShop.Models;
using OnlineShop.Models.Enums;
using OnlineShop.Models.Interfaces;

namespace OnlineShop;

public class OrderRepository(IRepositoryServices serviceRepository) : IRepositoryOrder
{
    private readonly List<Order> _baskets = [];
    
    
    public Order TryOrderById (Guid userId)
    {
        return _baskets.FirstOrDefault(item => item.UserId == userId);
    }
    
    public void SetOrder(Guid userId, Guid serviceId, ActionType action)
    {
        var userBasket = _baskets.FirstOrDefault(basket => basket.UserId == userId);
        var service = serviceRepository.TryServiceById(serviceId);

        if (userBasket == null)
        {
            userBasket = new Order()
            {
                UserId = userId,
                BasketPositions = new List<OrderPosition>()
            };
            _baskets.Add(userBasket);
        }

        var basketPosition = userBasket.BasketPositions.FirstOrDefault(bp => bp.Service.Id == service.Id);
        
        switch (action)
        {
            case ActionType.CLEAR:
                if (basketPosition != null)
                {
                    userBasket.BasketPositions.Remove(basketPosition);
                }
                break;
            case ActionType.APPROVE:
                if (basketPosition != null)
                {
                    // TODO тут надо записать все в Заказы
                    userBasket.BasketPositions.Remove(basketPosition);
                }
                break;
            case ActionType.ADD:
                if (basketPosition == null)
                {
                    basketPosition = new OrderPosition();
                    basketPosition.Service = service;
                    basketPosition.Count = 0;
                    
                    userBasket.BasketPositions.Add(basketPosition);
                }

                basketPosition.Count++;
                
                break;
            case ActionType.MINUS:
                if (basketPosition != null)
                {
                    basketPosition.Count--;
                    if (basketPosition.Count == 0)
                    {
                        userBasket.BasketPositions.Remove(basketPosition);
                    }
                }
                
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(action), action, null);
        }
    }
    
    
}