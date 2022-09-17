using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcRehber2.Models.Context;
using MvcRehber2.Models.Entities;
using MvcRehber2.Models.KisiModel;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MvcRehber2.Controllers
{
    public class KisiController : Controller
    {
        MvcRehber2Context db = new MvcRehber2Context();
        public IActionResult Index()
        {

            var LoginUser = (int)TempData["adminId"];
            TempData["adminID"] = LoginUser;

            var model = new KisiIndexViewModel
            {
                Kisiler = db.Kisiler.Where(x => x.UyeId == LoginUser).ToList(),
                Sehirler = db.Sehirler.ToList()
            };

            return View(model);

        }

        public ActionResult AdminIndex()
        {
            var model = new AdminIndexViewModel
            {
                Giris = db.Giris.ToList(),

            };

            return View(model);
        }

        public ActionResult AdminDetayliIndex()
        {
            var model = new AdminDetayliIndexViewModel
            {
                Giris = db.Giris.ToList(),
                Kisi = db.Kisiler.ToList(),

            };

            return View(model);
        }



        [HttpGet]

        public ActionResult AdminDetay(int id)
        {

            var uye = db.Giris.Find(id); //bu id'ye ait databasede üye varsa üye variable'ına ata

            if (uye == null)
            {
                TempData["HataliMesaj"] = "Üye bulunamadı!";
                return RedirectToAction("AdminIndex");
            }
            var model = new AdminDetayViewModel
            {
                Giris = uye,
               
            };
            return View(model);
        }
        public ActionResult AdminSil(int id)
        {
            var uye = db.Giris.Find(id);

            if (uye == null)
            {
                TempData["HataliMesaj"] = "Üye bulunamadı!";
                return RedirectToAction("AdminIndex");
            }

            db.Giris.Remove(uye); // Kisiler tablosundan bulunan kisiyi silecek
            db.SaveChanges(); // database güncelleme

            TempData["BasariliMesaj"] = "üye Bilgileri Başarıyla Silindi.";

            return RedirectToAction("AdminIndex");
        }


        [HttpGet]
        public ActionResult Ekle()
        {
            var id = TempData["adminID"];
            TempData["admin-id"] = id;
            TempData["adminId"] = TempData["admin-id"];


            var kisiBilgileri = db.Giris.Find(id);

            var model = new KisiEkleViewModel
            {
                Kisi = new Kisi(),
                Sehirler = db.Sehirler.ToList(),
                GirisBilgileri = kisiBilgileri

            };

            return View(model);
        }

        [HttpPost]

        public ActionResult Ekle(Kisi kisi)
        {
            TempData["adminId"] = TempData["adminId"];

            try
            {
                db.Kisiler.Add(kisi);
                db.SaveChanges();

                TempData["BasariliMesaj"] = "Ekleme İşlemi Başarıyla Gerçekleşti.";
            }
            catch (System.Exception)
            {
                TempData["HataliMesaj"] = "Hata Oluştu Lütfen Yeniden Deneyiniz!";

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var kisi = db.Kisiler.Find(id);

            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Güncellenmek istenen kayıt bulunamadı!";
                return RedirectToAction("Index");
            }
            var model = new KisiGuncelleViewModel
            {
                Kisi = kisi,
                Sehirler = db.Sehirler.ToList()
            };
            ViewBag.Sehirler = new SelectList(db.Sehirler.ToList(), "Id", "SehirAdi");


            return View(model);
        }
        [HttpPost]

        public ActionResult Guncelle(Kisi kisi)
        {
            var eskiKisi = db.Kisiler.Find(kisi.Id);


            if (eskiKisi == null)
            {
                TempData["HataliMesaj"] = "Güncellenmek istenen kayıt bulunamadı!";
                return RedirectToAction("Index");
            }

            eskiKisi.Ad = kisi.Ad;
            eskiKisi.Soyad = kisi.Soyad;
            eskiKisi.EvTelefon = kisi.EvTelefon;
            eskiKisi.CepTelefon = kisi.CepTelefon;
            eskiKisi.IsTelefon = kisi.IsTelefon;
            eskiKisi.EmailAdres = kisi.EmailAdres;
            eskiKisi.Adres = kisi.Adres;
            eskiKisi.SehirId = kisi.SehirId;

            db.SaveChanges();
            TempData["BasariliMesaj"] = "Kişi Bilgileri Başarıyla Güncellendi.";

            return RedirectToAction("Index");


        }

        [HttpGet]

        public ActionResult Detay(int id)
        {

            var kisi = db.Kisiler.Find(id); //bu id'ye ait databasede kişi varsa kisi variable'ına ata

            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Kişi bulunamadı!";
                return RedirectToAction("Index");
            }
            var model = new KisiDetayViewModel
            {
                Kisi = kisi,
                Sehirler = db.Sehirler.ToList()
            };
            return View(model);
        }
        public ActionResult Sil(int id)
        {
            var kisi = db.Kisiler.Find(id);

            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Kişi bulunamadı!";
                return RedirectToAction("Index");
            }

            db.Kisiler.Remove(kisi); // Kisiler tablosundan bulunan kisiyi silecek
            db.SaveChanges(); // database güncelleme

            TempData["BasariliMesaj"] = "Kişi Bilgileri Başarıyla Silindi.";

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Giris(Giris kullanici)
        {
            var infos = db.Giris.FirstOrDefault(x => x.MailAdresi == kullanici.MailAdresi && x.Sifre == kullanici.Sifre);

            if (infos != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, kullanici.MailAdresi),
                };

                var useridentity = new ClaimsIdentity(claims, "Giris");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                HttpContext.SignInAsync(principal);
                TempData["adminId"] = infos.UyeId;
                var admin = infos.MailAdresi;
                if (admin == "admin@gmail.com")
                {
                    return RedirectToAction("AdminIndex");
                }
                else
                {
                    return RedirectToAction("Index");
                }


            }
            else
            {
                TempData["HataliMesaj"] = "Şifrenizi ya da mail adresinizi kontrol ediniz!";
                return RedirectToAction("Giris");
            }
        }

        [HttpGet]

        public ActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kayit(Giris kullanici)
        {
            try
            {
                db.Giris.Add(kullanici);
                db.SaveChanges();

                TempData["BasariliMesaj"] = "Ekleme İşlemi Başarıyla Gerçekleşti.";
            }
            catch (System.Exception)
            {
                TempData["HataliMesaj"] = "Hata Oluştu Lütfen Yeniden Deneyiniz!";

            }

            return RedirectToAction("Giris");
        }
    }
}
