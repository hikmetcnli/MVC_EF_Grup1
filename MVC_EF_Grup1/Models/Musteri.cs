using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Grup1.Models
{
    public class Musteri
    {
        [Key]
        public int Id { get; set; }
        public string ?MusteriAdi { get; set; }
        public string ?MusteriSoyadi { get; set; }
        public string ?Adres { get; set; }
        public string ?Telefon { get; set; }

        public ICollection<SatinAlma> SatinAlmalar { get; set; }
    }
}
