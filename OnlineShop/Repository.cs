using Newtonsoft.Json;
using OnlineShop.Models;

namespace OnlineShop;

public class Repository : IRepository
{
    private readonly Guid _userId;
    private readonly List<Service> _services;
    private readonly List<Basket> _baskets;


    public Repository()
    {
        _userId = new Guid("3abbd50d-6634-44da-bffa-9cc072657214");
        _baskets = [];
        
        const string servicesJsonPath = "Data/Services.json";
        var json = File.ReadAllText(servicesJsonPath);
        _services = JsonConvert.DeserializeObject<List<Service>>(json) ?? [];
    }


    public Guid GetUserId()
    {
        return _userId;
    }
    
    
    public List<Service> GetServicesList()
    {
        return _services;
    }

    public Service? TryServiceById(Guid? id)
    {
        return _services.FirstOrDefault(service => service.Id == id);
    }
    
    
    
    public Basket TryBasketById (Guid userId)
    {
        return _baskets.FirstOrDefault(item => item.UserId == userId);
    }
    
    public void SetBasket(Guid userId, Guid serviceId, ActionType action)
    {
        var userBasket = _baskets.FirstOrDefault(basket => basket.UserId == userId);
        var service = TryServiceById(serviceId);

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