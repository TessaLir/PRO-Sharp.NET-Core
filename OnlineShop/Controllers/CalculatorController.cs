using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers;

public class CalculatorController : Controller
{
    public string Index(int a, int b)
    {
        return $"{a} + {b} = {a + b}";
    }
}