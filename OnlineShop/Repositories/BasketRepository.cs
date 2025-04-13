using OnlineShop.Models;

namespace OnlineShop;

public class BasketRepository(IRepositoryServices serviceRepository) : IRepositoryBasket
{
    private readonly List<Basket> _baskets = [];
    
    
    public Basket TryBasketById (Guid userId)
    {
        return _baskets.FirstOrDefault(item => item.UserId == userId);
    }
    
    public void SetBasket(Guid userId, Guid serviceId, ActionType action)
    {
        var userBasket = _baskets.FirstOrDefault(basket => basket.UserId == userId);
        var service = serviceRepository.TryServiceById(serviceId);

        if (userBasket == null)
        {
            userBasket = new Basket()
            {
                UserId = userId,
                BasketPositions = new List<BasketPosition>()
            };
            _baskets.Add(userBasket);
        }

        var basketPosition = userBasket.BasketPositions.FirstOrDefault(bp => bp.Service.Id == service.Id);
        
        switch (action)
        {
            case ActionType.ADD:
                if (basketPosition == null)
                {
                    basketPosition = new BasketPosition();
                    basketPosition.Service = service;
                    basketPosition.Count = 0;
                    
                    userBasket.BasketPositions.Add(basketPosition);
                }

                basketPosition.Count++;
                basketPosition.Cost = service.Cost * basketPosition.Count;
                
                break;
            case ActionType.MINUS:
                if (basketPosition != null)
                {
                    basketPosition.Count--;
                    if (basketPosition.Count != 0)
                    {
                        basketPosition.Cost = service.Cost * basketPosition.Count;
                    }
                    else
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