using Jobify.DataAccess.Repository.IRepository;
using Jobify.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index(string searchString)
        {
            IEnumerable<Punet> punetList;

            if (!String.IsNullOrEmpty(searchString))
            {
                punetList = _unitOfWork.Punet.GetAll().Where(p => p.Name.Contains(searchString));
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