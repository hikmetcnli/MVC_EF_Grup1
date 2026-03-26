using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Grup1.Models
{
    public class Arac
    {
        [Key]
        public int Id { get; set; }
        public int ModelYili { get; set; }

        [Required]
        [StringLength(50)]
        public string Marka { get; set; }
        [Required]
        [StringLength(20)]
        public string Plaka { get; set; }

        public decimal Fiyat { get; set; }
        public ICollection<SatinAlma> SatinAlmalar { get; set; }
    }
}
