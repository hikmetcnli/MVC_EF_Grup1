using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Grup1.Models;

namespace MVC_EF_Grup1.Controllers
{
    public class SatinAlmaController : Controller
    {
        Context c = new Context();
        public IActionResult Liste()
        {
            var SatinAlmaListesi = c.SatinAlmas_.Include(x=> x.Musteri).Include(x=>x.Arac).ToList();
            return View(SatinAlmaListesi);
        }
    }
}
