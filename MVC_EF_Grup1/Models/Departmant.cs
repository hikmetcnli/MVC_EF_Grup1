using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Grup1.Models
{
    public class Departmant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
