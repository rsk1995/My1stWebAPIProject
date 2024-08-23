using Microsoft.AspNetCore.Mvc;

namespace My1stWebAPIProject
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
