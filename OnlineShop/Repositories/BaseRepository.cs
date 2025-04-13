using OnlineShop.Models;
using OnlineShop.Models.Enums;
using OnlineShop.Models.Interfaces;

namespace OnlineShop.Repositories;

public class BaseRepository(
    IRepositoryServices serviceRepository,
    IRepositoryOrder orderRepository,
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


    public Order TryOrderById (Guid userId, OrderType? type)
    {
        return orderRepository.TryOrderById(userId, type);
    }
    
    public void SetOrder(Guid userId, ActionType action, Guid? serviceId)
    {
        orderRepository.SetOrder(userId, action, serviceId);
    }

}