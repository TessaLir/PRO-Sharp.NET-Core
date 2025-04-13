using OnlineShop.Models;
using OnlineShop.Models.Enums;
using OnlineShop.Models.Interfaces;

namespace OnlineShop;

public class OrderRepository(IRepositoryServices serviceRepository) : IRepositoryOrder
{
    private readonly List<Order> _baskets = [];
    
    
    public Order TryOrderById (Guid userId, OrderType? type)
    {
        if (type == null)
        {
            type = OrderType.IN_CART;
        }
        return _baskets.FirstOrDefault(item => item.UserId == userId && item.Type == type);
    }
    
    public void SetOrder(Guid userId, ActionType action, Guid? serviceId)
    {
        var userBasket = _baskets.FirstOrDefault(basket => basket.UserId == userId && basket.Type == OrderType.IN_CART);

        if (userBasket == null)
        {
            userBasket = new Order()
            {
                UserId = userId,
                BasketPositions = new List<OrderPosition>(),
                Type = OrderType.IN_CART
            };
            _baskets.Add(userBasket);
        }

        
        switch (action)
        {
            case ActionType.CLEAR:
                userBasket.BasketPositions = [];
                break;
            case ActionType.APPROVE:
                userBasket.Type = OrderType.IN_ORDER;
                break;
            case ActionType.ADD:
            case ActionType.MINUS:
                if (serviceId == null) break;
                var service = serviceRepository.TryServiceById(serviceId);
                var basketPosition = userBasket.BasketPositions.FirstOrDefault(bp => bp.Service.Id == serviceId);

                switch (action)
                {
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
                }
                
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(action), action, null);
        }
    }
    
    
}