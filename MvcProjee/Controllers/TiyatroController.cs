using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjee.Models.Entity;
namespace MvcProjee.Controllers
{
    public class TiyatroController : Controller
    {
        GeziEntities db = new GeziEntities();
        // GET: Tiyatro
        public ActionResult Index()
        {
            var deger = db.Table_TIYATRO.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniTiyatro()
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
        public ActionResult YeniTiyatro(Table_TIYATRO p1)
        {
            var ktg = db.Table_Kategori.Where(m => m.KategoriID == p1.Table_Kategori.KategoriID).FirstOrDefault();
            p1.Table_Kategori = ktg;
            db.Table_TIYATRO.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SIL(int id)
        {
            var tytr = db.Table_TIYATRO.Find(id);
            db.Table_TIYATRO.Remove(tytr);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult TiyatroGetir(int id)
        {
            var tyr = db.Table_TIYATRO.Find(id);
            List<SelectListItem> degerler = (from i in db.Table_Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("TiyatroGetir", tyr);

        }
        public ActionResult Guncelle(Table_TIYATRO p1)
        {
            var syht = db.Table_TIYATRO.Find(p1.TiyatroID);
            syht.TiyatroAdı = p1.TiyatroAdı;
            syht.TiyatroKonum = p1.TiyatroKonum;
            syht.Tiyatroİl = p1.Tiyatroİl;
            syht.Tiyatroİlce = p1.Tiyatroİlce;
            var ktg = db.Table_Kategori.Where(m => m.KategoriID == p1.Table_Kategori.KategoriID).FirstOrDefault();
            syht.Kategori_ID = p1.Table_Kategori.KategoriID;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}