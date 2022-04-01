using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjee.Models.Entity;


namespace MvcProjee.Controllers
{
    public class KonserController : Controller
    {
        GeziEntities db = new GeziEntities();
        // GET: Konser
        public ActionResult Index()
        {
            var deger = db.Table_Konser.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniKonser()
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
        public ActionResult YeniKonser(Table_Konser p1)
        {
            var ktg = db.Table_Kategori.Where(m => m.KategoriID == p1.Table_Kategori.KategoriID).FirstOrDefault();
            p1.Table_Kategori = ktg;

            db.Table_Konser.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var kns = db.Table_Konser.Find(id);
            db.Table_Konser.Remove(kns);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KonserGetir(int id)
        {
            var kns = db.Table_Konser.Find(id);
            List<SelectListItem> degerler = (from i in db.Table_Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("KonserGetir", kns);
        }
        public ActionResult Guncelle(Table_Konser p1)
        {
            var kns = db.Table_Konser.Find(p1.KonserID);
            kns.KonserAdı = p1.KonserAdı;
            kns.KonserKonumu = p1.KonserKonumu;
            kns.KonserTarihi = p1.KonserTarihi;
            kns.Konserİl = p1.Konserİl;
            kns.Konserİlce = p1.Konserİlce;
            var ktg = db.Table_Kategori.Where(m => m.KategoriID == p1.Table_Kategori.KategoriID).FirstOrDefault();
            kns.Kategori_ID = p1.Table_Kategori.KategoriID;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}