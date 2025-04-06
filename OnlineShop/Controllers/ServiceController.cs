using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers;

public class ServiceController : Controller
{
    private readonly ILogger<ServiceController> _logger;
    private readonly ServiceRepository _serviceRepository;

    public ServiceController(ILogger<ServiceController> logger)
    {
        _logger = logger;
        _serviceRepository = new ServiceRepository();
    }
    
    public string Index(Guid id)
    {
        var service = _serviceRepository.TryItemById(id);
        return service == null ? "Элемент не найден" : service + $"\r\n{service.Description}";
    }
}