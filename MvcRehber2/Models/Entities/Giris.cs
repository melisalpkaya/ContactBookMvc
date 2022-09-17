using System.ComponentModel.DataAnnotations;

namespace MvcRehber2.Models.Entities
{
    public class Giris
    {
        [Key]
        public int UyeId { get; set; }

        public string UyeAdi { get; set; }
        public string UyeSoyadi { get; set; }

        public int UyeTelefonNo { get; set; }
        public string MailAdresi { get; set; }
        public int Sifre { get; set; }
    }
}
