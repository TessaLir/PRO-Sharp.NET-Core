using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers;

public class CalculatorController : Controller
{
    public string Index(int a, int b, string method)
    {
        switch (method)
        {
            case "-":
                return $"{a} - {b} = {a - b}";
            case "*":
                return $"{a} * {b} = {a * b}";
        }
        
        return $"{a} + {b} = {a + b}";
    }
}