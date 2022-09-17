using MvcRehber2.Models.Entities;
using System.Collections.Generic;

namespace MvcRehber2.Models.KisiModel
{
    public class KisiEkleViewModel
    {
        public Kisi Kisi { get; set; }

        public Giris GirisBilgileri { get; set; }
        public List<Sehir> Sehirler { get; set; }
    }
}
