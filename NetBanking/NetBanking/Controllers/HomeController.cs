using Microsoft.AspNetCore.Mvc;

namespace NetBanking.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
