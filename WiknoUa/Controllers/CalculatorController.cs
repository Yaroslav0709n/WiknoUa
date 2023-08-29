using Microsoft.AspNetCore.Mvc;

namespace WiknoUa.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
