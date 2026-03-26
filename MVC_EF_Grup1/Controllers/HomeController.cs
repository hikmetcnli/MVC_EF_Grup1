using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_EF_Grup1.Models;

namespace MVC_EF_Grup1.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context(); 
          
        public IActionResult Index()
        {


            var ProductList = c.Products_.ToList();

            return View(ProductList);
        }

        [HttpGet]
        public IActionResult UrunEkle(int Id)
        {
            if (Id == 0)
                return View();
            else
            {
                var product = c.Products_.Find(Id);
                return View(product);
            }
        }

        [HttpPost]
        public IActionResult UrunEkle(Product product)
        {
            if (product.Id == 0) //Yeni Ürün Ekle
            {
                c.Products_.Add(product);
                c.SaveChanges();
            }
            else //Ürün Güncelle
            {
                var p = c.Products_.Find(product.Id);
                p.Name = product.Name;
                p.Description = product.Description;
                p.Price = product.Price;
                c.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
        public IActionResult UrunSil(int Id)
        {
            var p = c.Products_.Find(Id);
            if (p != null)
            {
                c.Products_.Remove(p);
                c.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {

            var DepartList = new List<SelectListItem>();
            
            foreach (var item in c.Departmants_.ToList())
            {
                DepartList.Add(
                    new SelectListItem { Value = item.Id.ToString(), Text = item.Name }
                    );
            }

            ViewBag.DepartmanListesi = DepartList;

            return View();
        }

        
    }
}
