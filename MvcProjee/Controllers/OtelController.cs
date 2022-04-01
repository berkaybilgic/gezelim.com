using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjee.Models.Entity;


namespace MvcProjee.Controllers
{
    public class OtelController : Controller
    {
        GeziEntities db = new GeziEntities();
        // GET: Otel
        public ActionResult Index()
        {
            var deger = db.Table_Otel.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniOtel()
        {
            List<SelectListItem> degerler = (from i in db.Table_Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();

        }
        [HttpPost]
        public ActionResult YeniOtel(Table_Otel p1)
        {
            var ktg = db.Table_Kategori.Where(m => m.KategoriID == p1.Table_Kategori.KategoriID).FirstOrDefault();
            p1.Table_Kategori = ktg;

            db.Table_Otel.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SIL(int id)
        {
            var otl = db.Table_Otel.Find(id);
            db.Table_Otel.Remove(otl);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult OtelGetir(int id)
        {
            var otl = db.Table_Otel.Find(id);
            List<SelectListItem> degerler = (from i in db.Table_Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("OtelGetir", otl);
        }
        public ActionResult Guncelle(Table_Otel p)
        {
            var otl = db.Table_Otel.Find(p.OtelID);
            otl.OtelAdı = p.OtelAdı;
            otl.OtelKonumu = p.OtelKonumu;
            otl.Otel_İl = p.Otel_İl;
            otl.Otel_İlce = p.Otel_İlce;
            var ktg = db.Table_Kategori.Where(m => m.KategoriID == p.Table_Kategori.KategoriID).FirstOrDefault();
            otl.Kategori_ID = p.Table_Kategori.KategoriID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}