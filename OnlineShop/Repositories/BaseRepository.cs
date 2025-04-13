using OnlineShop.Models;

namespace OnlineShop.Repositories;

public class BaseRepository(
    IRepositoryServices serviceRepository,
    IRepositoryBasket basketRepository,
    IRepositoryUser userRepository)
    : IRepository
{
    public Guid GetUserId()
    {
        return userRepository.GetUserId();
    }

    public List<Service> GetServicesList()
    {
        return serviceRepository.GetServicesList();
    }

    public Service? TryServiceById(Guid? id)
    {
        return serviceRepository.TryServiceById(id);
    }


    public Basket TryBasketById (Guid userId)
    {
        return basketRepository.TryBasketById(userId);
    }
    
    public void SetBasket(Guid userId, Guid serviceId, ActionType action)
    {
        basketRepository.SetBasket(userId, serviceId, action);
    }

}