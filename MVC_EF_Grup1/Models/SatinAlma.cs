using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Grup1.Models
{
    public class SatinAlma
    {
        [Key]
        public int Id { get; set; }
        public int MusteriID { get; set; }
        public virtual Musteri Musteri { get; set; }
        public int AracID { get; set; }
        public virtual Arac Arac { get; set; }
        public decimal AlimFiyati { get; set; }
        public DateTime AlimTarihi { get; set; }

    }
}
