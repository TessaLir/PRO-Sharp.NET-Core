using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly List<Service> _services = new()
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

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public string Index(Guid? id)
    {
        var result = "";

        if (id == null)
        {
            foreach (var service in _services)
            {
                result += service;
                result += "\r\n\r\n";
            }
        }
        else
        {
            var item = _services.FirstOrDefault(el => el.Id == id);
            result += item == null ? "Элемент не найден" : item + $"\r\n{item.Description}";
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
