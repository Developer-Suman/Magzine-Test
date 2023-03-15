using Microsoft.AspNetCore.Mvc;

namespace Megazine.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
