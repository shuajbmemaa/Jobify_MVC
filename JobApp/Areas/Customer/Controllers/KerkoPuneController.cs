using Jobify.DataAccess.Repository.IRepository;
using Jobify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class KerkoPuneController : Controller
    {
        private readonly ILogger<KerkoPuneController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public KerkoPuneController(ILogger<KerkoPuneController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        /*public IActionResult Index()
        {
            IEnumerable<Punet> listaPunes = _unitOfWork.Punet.GetAll();
            return View(listaPunes);
        }*/
        public IActionResult Index(string searchString,string kategoria)
        {
            
            var kategorite = _unitOfWork.Punet.GetKategorite();
            ViewBag.Categories = new SelectList(kategorite);

            IEnumerable<Punet> punetList = _unitOfWork.Punet.GetAll();

            if (!string.IsNullOrEmpty(kategoria))
            {
                punetList = punetList.Where(p => p.kategoria == kategoria);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                punetList = punetList.Where(p => p.Name.Contains(searchString));
            }
            else
            {
                punetList = _unitOfWork.Punet.GetAll();
            }

            return View(punetList);
        }

        public IActionResult Details(int id)
        {
            Punet puna = _unitOfWork.Punet.Get(u => u.Id == id);
            return View(puna);
        }
    }
}