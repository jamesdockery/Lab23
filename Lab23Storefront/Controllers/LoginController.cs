using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab23Storefront.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab23Storefront.Controllers
{
    public class LoginController : Controller
    {
        StoreContext db = new StoreContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User u)
        {
            TempData["Name"] = u.UserName;
            TempData["Password"] = u.Password;
            TempData["Money"] = u.Money;

            db.Add(u);
            db.SaveChanges();

            return RedirectToAction("Index", "Shop");


        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Name, string Password)
        {
            List<User> users = db.Users.ToList();

            for(int i = 0; i < users.Count; i++)
            {
                User u = users[i];

                if(u.UserName == Name && u.Password == Password)
                {
                    //Login the user
                    TempData["User"] = u;
                }
            }
            ViewBag.Error = "Incorrect User name or password, please register or try again";
            return RedirectToAction("Index", "Shop");
        }

    }
}