using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers;

public class CalculatorController : Controller
{
    public string Index(int a, int b, string method)
    {
        var tempLik = "https://localhost:7224/calculator/index/10/5/+";
        
        switch (method)
        {
            case "+":
                return $"{a} + {b} = {a + b}";
            case "-":
                return $"{a} - {b} = {a - b}";
            case "*":
                return $"{a} * {b} = {a * b}";
        }
        
        return "Вы ввели не корректный URL, введите URL в следующем формате, " + tempLik;
    }
}