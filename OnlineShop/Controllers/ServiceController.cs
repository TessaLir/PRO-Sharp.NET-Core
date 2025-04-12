using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Controllers;

public class ServiceController : Controller
{
    private readonly ILogger<ServiceController> _logger;
    private readonly IRepository _repository;

    public ServiceController(ILogger<ServiceController> logger, IRepository rep)
    {
        _logger = logger;
        _repository = rep;
    }
    
    public IActionResult Index(Guid id)
    {
        var service = _repository.TryServiceById(id);
        return View(service);
    }
}