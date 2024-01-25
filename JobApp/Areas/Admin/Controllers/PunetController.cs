using Jobify.DataAccess.Data;
using Jobify.DataAccess.Repository.IRepository;
using Jobify.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobApp.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
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
        public IActionResult Create(JobApp.Areas.Admin.Models.Punet obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var punet = new Punet()
                {
                    Id = obj.Id,
                    Name = obj.Name,
                    Description = obj.Description,
                    Kerkesat = obj.Kerkesat,
                    Lokacioni = obj.Lokacioni,
                    kategoria = obj.kategoria
                };

                if (file != null && file.Length > 0)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    var filePath = Path.Combine("wwwroot/images", uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    punet.ImageUrl = uniqueFileName;
                }
               

                _unitOfWork.Punet.Add(punet);
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
