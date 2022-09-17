using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcRehber2.Models.Entities
{
    [Table("Kisiler")]
    public class Kisi
    {
        
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        [DisplayName("Ev Telefonu")]
        public string EvTelefon { get; set; }

        [DisplayName("Cep Telefonu")]
        public string CepTelefon { get; set; }

        [DisplayName("İş Telefonu")]
        public string IsTelefon { get; set; }

        [DisplayName("Email Adresi")]
        public string EmailAdres { get; set; }

        public string Adres { get; set; }

        [DisplayName("Şehir")]
        public int SehirId { get; set; }

        public int UyeId { get; set; }  

        public virtual Giris Uye { get; set; }

        public virtual Sehir Sehir { get; set; }
    }
}
