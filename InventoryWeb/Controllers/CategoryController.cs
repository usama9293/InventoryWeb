using inventory.DataAccess.Data;
using Inventory.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db )
        {
            _db = db;
        }
        public IActionResult Index()
        {
           List<Category> categoryList= _db.Categories.ToList();
            return View(categoryList);
        }
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Category obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
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

            var categoryFromDb = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }




        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (_db.Categories.Any(c => c.Name == obj.Name && c.Id != obj.Id))
            {
                ModelState.AddModelError("Name", "Another category with this name already exists.");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: Category/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        // POST: Category/Delete
        [HttpPost, ActionName("Delete")]
       
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");
        }

    }

}
