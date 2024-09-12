using ITIProject.Context;
using ITIProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITIProject.Controllers
{
    public class UserController : Controller
    {
        MyConText DB = new MyConText();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            DB.Users.Add(user);
            DB.SaveChanges();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login()
            {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            //if (ModelState.IsValid) 
            //{
                var MyUser = DB.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                //var MyUser = DB.Users.FirstOrDefault(u => u.Email == email && u.Password == pass);
                if (MyUser != null)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login.");
                    Console.WriteLine(ModelState.ErrorCount);
                    return View(user);
                }
            //}
            // will write it
        }
    }
}
