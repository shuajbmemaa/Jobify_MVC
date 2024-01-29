using Jobify.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace JobApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AplikantetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AplikantetController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var aplikimet = _context.Aplikantet.ToList();
            return View(aplikimet);
        }
    }
}
