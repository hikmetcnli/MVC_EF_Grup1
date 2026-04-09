using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Grup1.Models;

namespace MVC_EF_Grup1.Controllers
{
    public class SatinAlmaController : Controller
    {
        Context c = new Context();
        public IActionResult Liste()
        {
            //Araç Sayısını bul
            ViewData["AracSayisi"] = c.Aracs_.ToList().Count;
            ViewData["MusteriSayisi"] = c.Musteris_.ToList().Count;


            var SatinAlmaListesi = c.SatinAlmas_.Include(x => x.Musteri).Include(x => x.Arac).ToList();
            return View(SatinAlmaListesi);
        }

        public IActionResult Create()
        {

            ViewBag.Musteriler = new SelectList(c.Musteris_, "Id", "MusteriAdi");
            ViewBag.Araclar = new SelectList(c.Aracs_, "Id", "Marka");

            return View();
        }

        [HttpPost]
        public IActionResult Create(SatinAlma s)
        {

            if (s.Id == 0)
            {
                s.AlimTarihi = DateTime.Now;
                c.SatinAlmas_.Add(s);
                c.SaveChanges();
            }
            else
            {
                c.SatinAlmas_.Update(s);
                c.SaveChanges();
            }
            return RedirectToAction("Liste", "SatinAlma");

        }


    }
}
