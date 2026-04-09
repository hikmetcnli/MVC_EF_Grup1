using Microsoft.AspNetCore.Mvc;
using MVC_EF_Grup1.Models;

namespace MVC_EF_Grup1.Controllers
{
    public class AracController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View(c.Aracs_.ToList());
        }
        [HttpGet]
        public IActionResult AracEkle(int id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                return View(c.Aracs_.Find(id));
            }

           
        }

        [HttpPost]
        public IActionResult AracEkle(Arac arac, IFormFile AracResmi)
        {


            if (AracResmi!=null && AracResmi.Length > 0)
            { 
                var dosyaAdi = Path.GetFileNameWithoutExtension(AracResmi.FileName)  +"_"+ DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")+ Path.GetExtension(AracResmi.FileName) ;
                var dosyaYolu = Path.Combine( Directory.GetCurrentDirectory(),"wwwroot","AracResimleri", dosyaAdi );


                using (var filestream = new FileStream(dosyaYolu,FileMode.Create))
                {
                    AracResmi.CopyTo(filestream);
                }

                arac.AracResmi = "/AracResimleri/" + dosyaAdi;
            }



            if (arac.Id == 0)
            {
                c.Aracs_.Add(arac);
                c.SaveChanges();
            }
            else
            {
                c.Aracs_.Update(arac);
                c.SaveChanges();
            }

            return RedirectToAction("Index", "Arac");
        }
    }
}
