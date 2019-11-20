using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab23Storefront.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab23Storefront.Controllers
{
    public class StoreController : Controller
    {
        StoreContext db = new StoreContext();
        public IActionResult Index()
        {
            List<Product> allProducts = db.Products.ToList();

            return View(allProducts);
        }



        public IActionResult Buy(int id)
        {
            Product p = db.Products.Find(id);
            if (p != null)
            {
                return View(p);
            }
            else
            {
                return RedirectToAction("Index", "Product");
            }
        }
    }
}