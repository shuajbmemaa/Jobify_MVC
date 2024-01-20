using Jobify.DataAccess.Data;
using Jobify.DataAccess.Repository.IRepository;
using Jobify.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PunetController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PunetController(IUnitOfWork unitOfWork,IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Punet> objPunetList = _unitOfWork.Punet.GetAll().ToList();
            return View(objPunetList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Punet obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Punet.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Kateogria u perditesua me sukses";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Punet? punetFromDb = _unitOfWork.Punet.Get(u => u.Id == id);
            //Punet? punetFromDb2=_db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (punetFromDb == null)
            {
                return NotFound();
            }
            return View(punetFromDb);
        }

        [HttpPost]
        public IActionResult Create(Punet obj,IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName=Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string punetPath=Path.Combine(wwwRootPath, @"images\punet");

                    using (var fileStream = new FileStream(Path.Combine(punetPath, fileName),FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.ImageUrl = @"\images\punet\" + fileName;
                    Console.WriteLine($"ImageUrl: {obj.ImageUrl}");

                }
                _unitOfWork.Punet.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Puna u krijua me sukses";
                return RedirectToAction("Index", "Punet");
            }
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Punet? obj = _unitOfWork.Punet.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Punet.Delete(obj);
            _unitOfWork.Save();
            TempData["success"] = "Kateogria u fshie me sukses";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Punet? punetFromDb = _unitOfWork.Punet.Get(u => u.Id == id);
            if (punetFromDb == null)
            {
                return NotFound();
            }
            return View(punetFromDb);
        }
    }
}
