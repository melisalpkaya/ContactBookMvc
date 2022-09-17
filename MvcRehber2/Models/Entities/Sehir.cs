using System.ComponentModel.DataAnnotations.Schema;

namespace MvcRehber2.Models.Entities
{
    [Table("Sehirler")]
    public class Sehir
    {
        public int Id { get; set; }
        public string SehirAdi { get; set; }
        public int PlakaKodu { get; set; }
   
    }
}
