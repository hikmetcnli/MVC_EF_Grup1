using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Grup1.Models;

namespace MVC_EF_Grup1.Controllers
{
    public class DashboardController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            ViewBag.MusteriSayisi = c.Musteris_.Count();
            ViewBag.AracSayisi = c.Aracs_.Count();
            ViewBag.ToplamSatinAlma = c.SatinAlmas_.Sum(x => x.AlimFiyati);
            ViewBag.SonBirAydakiSatinAlma = c.SatinAlmas_.Where(x => x.AlimTarihi >= DateTime.Now.AddDays(-30)).Sum(x => x.AlimFiyati);


            //Trend Raporları
            //ViewBag.CountriesText = new List<string> { "Italy", "France", "Spain", "USA", "Argentina" };
            //ViewBag.CountriesValue = new List<int> { 55, 49, 44, 24, 15 };

            var aylikAlimFiyatlari = c.SatinAlmas_.
                        GroupBy(x => new { x.AlimTarihi.Year, x.AlimTarihi.Month }).
                        Select(y => new
                        {
                            Donem = y.Key.Year.ToString() + "/" + y.Key.Month.ToString(),
                            ToplamSatinAlmaFiyat = y.Sum(s => s.AlimFiyati)
                        }).
                OrderByDescending(y => y.Donem).ToList();

            List<string> SatinAlmaText = new List<string>();
            List<int> SatinAlmaValue = new List<int>();

            foreach(var dr in aylikAlimFiyatlari)
            {
                SatinAlmaText.Add(dr.Donem);
                SatinAlmaValue.Add( Convert.ToInt32(dr.ToplamSatinAlmaFiyat));
            }

            ViewBag.SatinAlmaText = SatinAlmaText;
            ViewBag.SatinAlmaValue = SatinAlmaValue;

            //


            var SonSatinAlmaKayitlari = c.SatinAlmas_.
                        Include(x=>x.Musteri).
                        Include(x=>x.Arac).
                        OrderByDescending(x => x.AlimTarihi).
                        Take(3).
                        ToList();

            return View(SonSatinAlmaKayitlari);
        }
    }
}
