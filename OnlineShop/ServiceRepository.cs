using OnlineShop.Models;

namespace OnlineShop;

public class ServiceRepository
{
    private static readonly List<Service> _services = new()
    {
        new Service
        {
            Id = new Guid("ecd4480b-235c-4a91-9b88-64787c3748bf"), 
            Name = "Service 01", 
            Cost = 100.50, 
            Description = "Descr - 001"
        },
        new Service
        {
            Id = new Guid("8703089e-0e0b-4c58-9c33-30419aa7b56e"), 
            Name = "Service 02", 
            Cost = 200.45, 
            Description = "Descr - 002"
        },
        new Service
        {
            Id = new Guid("05acd97a-1fe2-4168-bd15-43daa8a620b6"), 
            Name = "Service 03", 
            Cost = 300.55, 
            Description = "Descr - 003"
        },
    };

    public List<Service> GetList()
    {
        return _services;
    }

    public Service? TryItemById(Guid? id)
    {
        return _services.FirstOrDefault(service => service.Id == id);
    }
}