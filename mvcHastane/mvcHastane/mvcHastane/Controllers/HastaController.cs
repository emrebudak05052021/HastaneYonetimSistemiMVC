using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcHastane.Models;
namespace mvcHastane.Controllers
{
    public class HastaController : Controller
    {
        db_HastaneYonetimSistemiEntities db = new db_HastaneYonetimSistemiEntities();
        // GET: Hasta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult hastaListele()
        {
            var hastaListesi = db.tbl_Hasta.ToList();
            return View(hastaListesi);
        }

        //YENİ HASTA EKLE
        [HttpGet]
        public ActionResult HastaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HastaEkle(tbl_Hasta p1)
        {
            db.tbl_Hasta.Add(p1);
            db.SaveChanges();
            return RedirectToAction("hastaListele");
        }

        //HASTA SİL
        public ActionResult Sil(int? id)
        {
            var silinecekHasta = db.tbl_Hasta.Find(id);
            db.tbl_Hasta.Remove(silinecekHasta);
            db.SaveChanges();
            return RedirectToAction("hastaListele");
        }
        //HASTA GÜNCELLE
        public ActionResult hastaGetir(int? id)
        {
            var hst = db.tbl_Hasta.Find(id);
            return View("hastaGetir",hst);
        }
        public ActionResult Guncelle(tbl_Hasta p1)
        {
            var hst = db.tbl_Hasta.Find(p1.hastaID);
            hst.hastaAd = p1.hastaAd;
            hst.hastaSoyad = p1.hastaSoyad;
            hst.hastaTc = p1.hastaTc;
            hst.hastaYas = p1.hastaYas;
            hst.hastaCinsiyet = p1.hastaCinsiyet;
            hst.kronikRahatsizlik = p1.kronikRahatsizlik;
            hst.hastaTelefon = p1.hastaTelefon;
            hst.kayitTarih = p1.kayitTarih;
            db.SaveChanges();
            return RedirectToAction("hastaListele");

        }
    }
}