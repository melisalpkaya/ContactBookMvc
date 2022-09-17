using MvcRehber2.Models.Entities;
using System.Data.Entity;

namespace MvcRehber2.Models.Context
{
    public class MvcRehber2Context : DbContext
    {
        public MvcRehber2Context() : base(@"Server=.; Database=MvcRehber2DB;uid=sa;pwd=123456")
        {

        }
        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }

        public DbSet<Giris> Giris { get; set; }

    }
}
