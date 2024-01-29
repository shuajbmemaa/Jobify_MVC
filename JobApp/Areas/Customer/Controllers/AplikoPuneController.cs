using Jobify.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Jobify.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace JobApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = "Admin, Punekerkuesi")]
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
        public IActionResult Apply(Aplikimi model)
        {
            if (ModelState.IsValid)
            {
                // Check if the user has already applied
                bool hasAlreadyApplied = _unitOfWork.Aplikimi.Exists(a => a.Name == model.Name);

                if (!hasAlreadyApplied)
                {
                    _unitOfWork.Aplikimi.Add(model); // Implement this to save in the database
                    _unitOfWork.Save();
                    ViewBag.ConfirmationMessage = "Your application has been submitted successfully!";
                }
                else
                {
                    ViewBag.ErrorMessage = "You have already applied!";
                }

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
