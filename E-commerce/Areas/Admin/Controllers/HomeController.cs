using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Area.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
