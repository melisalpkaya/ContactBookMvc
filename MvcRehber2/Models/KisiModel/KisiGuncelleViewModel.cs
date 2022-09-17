using MvcRehber2.Models.Entities;
using System.Collections.Generic;

namespace MvcRehber2.Models.KisiModel
{
    public class KisiGuncelleViewModel
    {
        public Kisi Kisi { get; set; }
        public List<Sehir> Sehirler { get; set; }
    }
}
