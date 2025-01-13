using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcHastane.Models;
namespace mvcHastane.Controllers
{
    public class TedaviController : Controller
    {
        db_HastaneYonetimSistemiEntities db = new db_HastaneYonetimSistemiEntities();
        // GET: Tedavi
        public ActionResult tedaviListele()
        {
            var dkt = db.tbl_Tedavi.ToList();
            return View(dkt);
        }

        //RANDEVU EKLE
        [HttpGet]
        public ActionResult TedaviEkle()
        {
            var hastaDegerler = (from i in db.tbl_Hasta.ToList()
                                 select new SelectListItem
                                 {
                                     Text = i.hastaAd + i.hastaSoyad,
                                     Value = i.hastaID.ToString()
                                 }).ToList();
            ViewBag.dgrhst = hastaDegerler;
            var doktorDegerler = (from i in db.tbl_Doktorlar.ToList()
                                  select new SelectListItem
                                  {
                                      Text = i.doktorAd + i.doktorSoyad,
                                      Value = i.doktorID.ToString()
                                  }).ToList();
            ViewBag.dgrdkt = doktorDegerler;
            return View();
        }
        [HttpPost]
        public ActionResult TedaviEkle(tbl_Tedavi p1)
        {
            db.tbl_Tedavi.Add(p1);
            db.SaveChanges();
            return RedirectToAction("tedaviListele");
        }

        //RANDEVU GÜNCELLE

        public ActionResult TedaviGetir(int? id)
        {
            var hastaDegerler = (from i in db.tbl_Hasta.ToList()
                                 select new SelectListItem
                                 {
                                     Text = i.hastaAd + i.hastaSoyad,
                                     Value = i.hastaID.ToString()
                                 }).ToList();
            ViewBag.dgrhst = hastaDegerler;
            var doktorDegerler = (from i in db.tbl_Doktorlar.ToList()
                                  select new SelectListItem
                                  {
                                      Text = i.doktorAd + i.doktorSoyad,
                                      Value = i.doktorID.ToString()
                                  }).ToList();
            ViewBag.dgrdkt = doktorDegerler;
            var rnd = db.tbl_Tedavi.Find(id);
            return View("TedaviGetir", rnd);
        }
        public ActionResult Guncelle(tbl_Tedavi p2)
        {
            var rnd = db.tbl_Tedavi.Find(p2.tedaviID);
            rnd.hastaID = p2.hastaID;
            rnd.doktorID = p2.doktorID;
            rnd.tedaviIcerik = p2.tedaviIcerik;
            rnd.tarih = p2.tarih;
            rnd.recete = p2.recete;
            rnd.fiyat = p2.fiyat;

            db.SaveChanges();
            return RedirectToAction("tedaviListele");
        }

        //TEDAVİ SİL

        public ActionResult Sil(int? id)
        {
            var tdv = db.tbl_Tedavi.Find(id);
            db.tbl_Tedavi.Remove(tdv);
            db.SaveChanges();
            return RedirectToAction("tedaviListele");
        }
    }
}