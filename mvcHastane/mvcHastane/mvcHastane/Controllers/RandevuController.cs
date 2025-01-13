using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcHastane.Models;
namespace mvcHastane.Controllers
{
    public class RandevuController : Controller
    {
        db_HastaneYonetimSistemiEntities db = new db_HastaneYonetimSistemiEntities();
        // GET: Randevu
        public ActionResult randevuListele()
        {
            var dktListe = db.tbl_Randevu.ToList();
            return View(dktListe);
        }

        //RANDEVU EKLE
        [HttpGet]
        public ActionResult RandevuEkle()
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
        public ActionResult RandevuEkle(tbl_Randevu p1)
        {
            db.tbl_Randevu.Add(p1);
            db.SaveChanges();
            return RedirectToAction("randevuListele");
        }


        //RANDEVU GÜNCELLE

        public ActionResult RandevuGetir(int? id)
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
            var rnd = db.tbl_Randevu.Find(id);
            return View("RandevuGetir", rnd);
        }
        public ActionResult Guncelle(tbl_Randevu p2)
        {
            var rnd = db.tbl_Randevu.Find(p2.randevuID);
            rnd.hastaID = p2.hastaID;
            rnd.doktorID = p2.doktorID;
            rnd.olusturmaTarih = p2.olusturmaTarih;
            rnd.randevuTarih = p2.randevuTarih; 
            db.SaveChanges();
            return RedirectToAction("randevuListele");
        }

        //RANDEVU SİL

        public ActionResult Sil(int? id)
        {
            var rnd = db.tbl_Randevu.Find(id);
            db.tbl_Randevu.Remove(rnd);
            db.SaveChanges();
            return RedirectToAction("randevuListele");
        }
    }
}