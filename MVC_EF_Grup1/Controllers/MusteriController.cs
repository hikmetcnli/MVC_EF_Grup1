using Microsoft.AspNetCore.Mvc;
using MVC_EF_Grup1.Models;

namespace MVC_EF_Grup1.Controllers
{
    public class MusteriController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View(c.Musteris_.ToList());
        }
        [HttpGet]
        public IActionResult MusteriEkle(int id )
        {
            var Guncellenicek = c.Musteris_.Find(id);
            return View(Guncellenicek);
        }

        [HttpPost]
        public IActionResult MusteriEkle(Musteri musteri)
        {
            if (musteri.Id == 0)
            {
                c.Musteris_.Add(musteri);
                c.SaveChanges();
            }
            else
            {
                c.Musteris_.Update(musteri);
                c.SaveChanges();
            }

                return RedirectToAction("Index", "Musteri");
        }
        public IActionResult MusteriSil(int id)
        {
            var SilinecekMusteri = c.Musteris_.Find(id);
            c.Musteris_.Remove(SilinecekMusteri);
            c.SaveChanges();

            return RedirectToAction("Index", "Musteri");
        }



    }
}
