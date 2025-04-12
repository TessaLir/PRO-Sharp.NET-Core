using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Controllers;

public class BasketController : Controller
{
    private readonly ILogger<ServiceController> _logger;
    private readonly BasketRepository _basketRepository;
    private readonly Guid _userID = new Guid("3abbd50d-6634-44da-bffa-9cc072657214"); // TODO потом нужно будет получать из DI

    public BasketController(ILogger<ServiceController> logger)
    {
        _logger = logger;
        _basketRepository = new BasketRepository();
    }
    
    public IActionResult Index()
    {
        var basket = _basketRepository.TryItemById(_userID);
        return View(basket);
    }

    public IActionResult AddItem(Guid serviceId, ActionType actionType)
    {
        _basketRepository.SetItem(_userID, serviceId, actionType);

        var basket = _basketRepository.TryItemById(_userID);
        return View("Index", basket);
    }
}