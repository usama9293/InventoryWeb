﻿using InventoryWeb.Data;
using InventoryWeb.Models;
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
    }
}
