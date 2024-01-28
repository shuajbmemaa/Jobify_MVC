using Jobify.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Jobify.Models;

namespace JobApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AplikoPuneController : Controller
    {
        private readonly ILogger<AplikoPuneController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public AplikoPuneController(ILogger<AplikoPuneController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public IActionResult Apply(JobApplicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Process the application (e.g., send email, save to database, etc.)
                /// Set a confirmation message to be displayed
                ViewBag.ConfirmationMessage = "Your application has been submitted successfully!";
                return View("Index");
            }
            return View("Index", model);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
