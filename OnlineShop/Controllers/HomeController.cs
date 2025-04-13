using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Models.Interfaces;

namespace OnlineShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepository _repository;

    public HomeController(ILogger<HomeController> logger, IRepository rep)
    {
        _logger = logger;
        _repository = rep;
    }

    public IActionResult Index()
    {
        var list = _repository.GetServicesList();
        return View(list);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
