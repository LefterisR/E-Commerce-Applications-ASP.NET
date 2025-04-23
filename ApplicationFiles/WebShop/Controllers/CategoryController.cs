using Microsoft.AspNetCore.Mvc;
using WebShop.DataAccess.Data;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class CategoryController(ApplicationDbContext db) : Controller
    {

        private readonly ApplicationDbContext _db = db;

        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name","The Display Order cannot be the same as the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();

        }


        public IActionResult Edit(int? id) {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            
            Category? categoryFromDb = _db.Categories.Find(id);
           
            if (categoryFromDb == null) { 
                return NotFound();
            }

            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category category) {

            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot be the same as the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index", "Category");
            }
            return View(category);
        }

        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {   
            Category? categoryToRemove = _db.Categories.Find(id);

            if (categoryToRemove == null) {
                return NotFound();
            }

            _db.Categories.Remove(categoryToRemove);
            TempData["success"] = "Category deleted successfully";
            _db.SaveChanges();
           
            return RedirectToAction("Index", "Category");
        }
    }
}
