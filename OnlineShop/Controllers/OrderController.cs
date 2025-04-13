using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Models.Enums;
using OnlineShop.Models.Interfaces;

namespace OnlineShop.Controllers;

public class OrderController : Controller
{
    private readonly ILogger<ServiceController> _logger;
    private readonly IRepository _repository;

    public OrderController(ILogger<ServiceController> logger, IRepository rep)
    {
        _logger = logger;
        _repository = rep;
    }
    
    public IActionResult Index()
    {
        var order = _repository.TryOrderById(_repository.GetUserId());
        return View(order);
    }

    public IActionResult AddItem(Guid serviceId, ActionType actionType)
    {
        _repository.SetOrder(_repository.GetUserId(), serviceId, actionType);
        return RedirectToAction("Index");
    }

    public IActionResult ApproveOrder()
    {
        
        return RedirectToAction("Index");
    }
}