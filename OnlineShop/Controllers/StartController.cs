using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers;

public class StartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public string Hello()
    {
        var result = "Добрый вечер";
        var date = DateTime.Now;

        var nigth = DateTime.Today;
        var morning = DateTime.Today.AddHours(6);
        var day = DateTime.Today.AddHours(12);
        var evening = DateTime.Today.AddHours(18);

        if (date >= nigth && date < morning)
        {
            result = "Доброй ночи";
        }
        else if (date >= morning && date < day)
        {
            result = "Доброе утро";
        }
        else if (date >= day && date < evening)
        {
            result = "Добрый день";
        }
            
        return result;
    }
}