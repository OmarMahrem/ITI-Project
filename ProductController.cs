using ITIProject.Context;
using ITIProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITIProject.Controllers
{
    public class ProductController : Controller
    {
        MyConText DB = new MyConText();
        [HttpGet]
        public IActionResult Index()
        {
            var products = DB.Products.Include(p => p.Category).ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = DB.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag.Categories = DB.Categories.ToList();
            ViewBag.Categories = new SelectList(DB.Categories, "CategoryId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                DB.Products.Add(product);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(DB.Categories, "CategoryId", "Name");
            return View(product);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = DB.Products.Find(id);

            if (product == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(DB.Categories, "CategoryId", "Name");
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                DB.Products.Update(product);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(DB.Categories, "CategoryId", "Name");
            return View(product);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = DB.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = DB.Products.Find(id);
            if (product != null)
            {
                DB.Products.Remove(product);
                DB.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
