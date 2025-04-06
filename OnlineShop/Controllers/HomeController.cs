using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ServiceRepository _serviceRepository;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _serviceRepository = new ServiceRepository();
    }

    public string Index(Guid? id)
    {
        var result = "";

        foreach (var service in _serviceRepository.GetList())
        {
            result += service;
            result += "\n\n";
        }
        
        return result;
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
