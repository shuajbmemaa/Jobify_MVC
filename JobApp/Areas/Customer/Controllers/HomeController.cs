using Jobify.DataAccess.Repository.IRepository;
using Jobify.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = "Admin, Punedhenesi, Punekerkuesi")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        //[Authorize(Roles = "Admin, Punedhenesi")]
        public IActionResult Index()
        {
            IEnumerable<Punet> listaPunes=_unitOfWork.Punet.GetAll();
            return View(listaPunes);
        }

        //[Authorize(Roles = "Punekerkuesi")]
        public IActionResult Index1()
        {
            return View();
        }


        public IActionResult Details(int id)
        {
            Punet puna = _unitOfWork.Punet.Get(u => u.Id==id);
            return View(puna);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}