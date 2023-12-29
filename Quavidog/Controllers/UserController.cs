using Microsoft.AspNetCore.Mvc;

namespace Quavidog.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
