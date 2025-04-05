using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers;

public class CalcController : Controller
{
    public string Index(double a = 0, double b = 0, string c = "+")
    {
        var tempLik = "https://localhost:7224/calc/index?a=3&b=6&c=-";

        switch (c)
        {
            case "+":
                return $"{a} + {b} = {a + b}";
            case "-":
                return $"{a} - {b} = {a - b}";
            case "*":
                return $"{a} * {b} = {a * b}";
            case "/":
                return $"{a} / {b} = {a / b}";
        }

        return "Вы ввели не корректный URL, введите URL в следующем формате, " + tempLik;
    }
}