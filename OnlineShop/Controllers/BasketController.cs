using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Controllers;

public class BasketController : Controller
{
    private readonly ILogger<ServiceController> _logger;
    private readonly IRepository _repository;

    public BasketController(ILogger<ServiceController> logger, IRepository rep)
    {
        _logger = logger;
        _repository = rep;
    }
    
    public IActionResult Index()
    {
        var basket = _repository.TryBasketById(_repository.GetUserId());
        return View(basket);
    }

    public IActionResult AddItem(Guid serviceId, ActionType actionType)
    {
        _repository.SetBasket(_repository.GetUserId(), serviceId, actionType);
        return RedirectToAction("Index");
    }
}