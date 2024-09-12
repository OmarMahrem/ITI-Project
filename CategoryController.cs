using ITIProject.Context;
using ITIProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITIProject.Controllers
{
    public class CategoryController : Controller
    {
        MyConText DB = new MyConText();
        [HttpGet]
        public IActionResult Index()
        {
            var Categorys = DB.Categories.ToList();
            return View(Categorys);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var category = DB.Categories.Include(c => c.Products).FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                DB.Categories.Add(category);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = DB.Categories.Find(id);

            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                DB.Categories.Update(category);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = DB.Categories.Find(id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = DB.Categories.Find(id);
            if (category != null)
            {
                DB.Categories.Remove(category);
                DB.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
