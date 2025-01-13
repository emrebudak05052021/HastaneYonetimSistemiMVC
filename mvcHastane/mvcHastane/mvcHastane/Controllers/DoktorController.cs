using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcHastane.Models;
namespace mvcHastane.Controllers
{
    public class DoktorController : Controller
    {
        db_HastaneYonetimSistemiEntities db = new db_HastaneYonetimSistemiEntities();
        // GET: Doktor

        //DOKTOR LİSTELE
        public ActionResult doktorListele()
        {
            var dkt = db.tbl_Doktorlar.ToList();
            return View(dkt);
        }


        //DOKTOR EKLE
        [HttpGet]
        public ActionResult DoktorEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoktorEkle(tbl_Doktorlar p1)
        {
            db.tbl_Doktorlar.Add(p1);
            db.SaveChanges();
            return RedirectToAction("doktorListele");
        }

        //DOKTOR SİL
        public ActionResult Sil(int? id)
        {
            var dkt = db.tbl_Doktorlar.Find(id);
            db.tbl_Doktorlar.Remove(dkt);
            db.SaveChanges();
            return RedirectToAction("doktorListele");
        }

        //DOKTOR GÜNCELLE

        public ActionResult DoktorGetir(int? id)
        {
            var hst = db.tbl_Doktorlar.Find(id);
            return View("DoktorGetir",hst);
        }

        public ActionResult Guncelle(tbl_Doktorlar p1)
        {
            var dkt = db.tbl_Doktorlar.Find(p1.doktorID);
            dkt.doktorAd = p1.doktorAd;
            dkt.doktorSoyad = p1.doktorSoyad;
            dkt.doktorUzmanlik = p1.doktorUzmanlik;
            dkt.durum = p1.durum;
            db.SaveChanges();
            return RedirectToAction("doktorListele");
        }
    }
}