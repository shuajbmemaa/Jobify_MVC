using Jobify.DataAccess.Data;
using Jobify.DataAccess.Repository.IRepository;
using Jobify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace JobApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PunaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PunaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Puna> objPunaList = _unitOfWork.Puna.GetAll().ToList();
             
            return View(objPunaList);
        }

        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.
            //    GetAll().Select(u => new SelectListItem
            //    {
            //        Text = u.Name,
            //        Value = u.Id.ToString()
            //    });

            //ViewBag.CategoryList = CategoryList;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Puna obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Puna.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Puna u perditesua me sukses";
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
            Puna? punaFromDb = _unitOfWork.Puna.Get(u => u.Id == id);
            //Puna? punaFromDb2=_db.Puna.Where(u=>u.Id==id).FirstOrDefault();
            if (punaFromDb == null)
            {
                return NotFound();
            }
            return View(punaFromDb);
        }

        [HttpPost]
        public IActionResult Create(Puna obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Puna.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Puna u krijua me sukses";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Puna? obj = _unitOfWork.Puna.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Puna.Delete(obj);
            _unitOfWork.Save();
            TempData["success"] = "Puna u fshie me sukses";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Puna? punaFromDb = _unitOfWork.Puna.Get(u => u.Id == id);
            if (punaFromDb == null)
            {
                return NotFound();
            }
            return View(punaFromDb);
        }
    }
}
