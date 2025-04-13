using Newtonsoft.Json;
using OnlineShop.Models;
using OnlineShop.Models.Interfaces;

namespace OnlineShop;

public class ServiceRepository : IRepositoryServices
{
    private readonly List<Service> _services;

    
    public ServiceRepository()
    {
        const string servicesJsonPath = "Data/Services.json";
        var json = File.ReadAllText(servicesJsonPath);
        _services = JsonConvert.DeserializeObject<List<Service>>(json) ?? [];
    }
    
    
    public List<Service> GetServicesList()
    {
        return _services;
    }

    public Service? TryServiceById(Guid? id)
    {
        return _services.FirstOrDefault(service => service.Id == id);
    }
    
}