using inventory.DataAccess.Repository;
using Inventory.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }

        public IActionResult Index()
        {
            List<Category> categoryList = _categoryRepo.GetAll().ToList();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj == null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                _categoryRepo.Add(obj);
                _categoryRepo.save();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var categoryFromDb = _categoryRepo.Get(c => c.Id == id);
            if (categoryFromDb == null)
                return NotFound();

            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj == null)
                return BadRequest();

            var allCategories = _categoryRepo.GetAll();
            if (allCategories.Any(c => c.Name == obj.Name && c.Id != obj.Id))
            {
                ModelState.AddModelError("Name", "Another category with this name already exists.");
            }

            if (ModelState.IsValid)
            {
                _categoryRepo.Update(obj);
                _categoryRepo.save();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var categoryFromDb = _categoryRepo.Get(c => c.Id == id);
            if (categoryFromDb == null)
                return NotFound();

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _categoryRepo.Get(c => c.Id == id);
            if (obj == null)
                return NotFound();

            _categoryRepo.Remove(obj);
            _categoryRepo.save();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
