using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly List<Service> _services = new()
    {
        new Service { Id = Guid.NewGuid(), Name = "Service 01", Cost = 100.50, Description = "Descr - 001" },
        new Service { Id = Guid.NewGuid(), Name = "Service 02", Cost = 200.45, Description = "Descr - 002" },
        new Service { Id = Guid.NewGuid(), Name = "Service 03", Cost = 300.55, Description = "Descr - 003" },
    };

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public string Index()
    {
        var result = "";

        foreach (var service in _services)
        {
            result += service;
            result += "\r\n\r\n";
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
