using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Admin_Panel.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
