using OnlineShop.Models;

namespace OnlineShop;

public class BasketRepository
{
    private static List<Basket> _basket = new List<Basket>();

    public void SetItem(Guid userId, Guid serviceId, ActionType action)
    {
        var userBasket = _basket.FirstOrDefault(basket => basket.UserId == userId);
        var serviceRepository = new ServiceRepository();

        var service = serviceRepository.TryItemById(serviceId);

        if (userBasket == null)
        {
            userBasket = new Basket()
            {
                UserId = userId,
                BasketPositions = new List<BasketPosition>()
            };
            _basket.Add(userBasket);
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
        }
    }


    public Basket TryItemById (Guid userId)
    {
        return _basket.FirstOrDefault(item => item.UserId == userId);
    }
    

}