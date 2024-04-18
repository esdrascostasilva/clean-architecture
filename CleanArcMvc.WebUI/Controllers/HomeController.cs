using Microsoft.AspNetCore.Mvc;

namespace CleanArcMvc.WebUI;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
