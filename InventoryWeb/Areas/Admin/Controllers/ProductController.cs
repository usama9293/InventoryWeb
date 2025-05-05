using inventory.DataAccess.Repository;
using Inventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;

        public ProductController(IProductRepository db, ICategoryRepository categoryRepo)
        {
            _productRepo = db;
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            List<Product> productList = _productRepo.GetAll().ToList();
          
            return View(productList);

        }

        public IActionResult Create()
        {
            ViewBag.CategoryList = _categoryRepo.GetAll()
       .Select(c => new SelectListItem
       {
           Text = c.Name,
           Value = c.Id.ToString()
       });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product obj)
        {
            if (obj == null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                _productRepo.Add(obj);
                _productRepo.save();
                TempData["success"] = "Product created successfully!";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var categoryFromDb = _productRepo.Get(c => c.Id == id);
            if (categoryFromDb == null)
                return NotFound();

            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            if (obj == null)
                return BadRequest();

            var allCategories = _productRepo.GetAll();
           

            if (ModelState.IsValid)
            {
                _productRepo.Update(obj);
                _productRepo.save();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var productFromDb = _productRepo.Get(c => c.Id == id);
            if (productFromDb == null)
                return NotFound();

            return View(productFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _productRepo.Get(c => c.Id == id);
            if (obj == null)
                return NotFound();

            _productRepo.Remove(obj);
            _productRepo.save();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
