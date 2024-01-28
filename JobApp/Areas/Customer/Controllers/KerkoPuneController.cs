using Microsoft.AspNetCore.Mvc;

namespace JobApp.Areas.Customer.Controllers
{
    public class KerkoPuneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
