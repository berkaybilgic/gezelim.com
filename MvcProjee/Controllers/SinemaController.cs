using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjee.Models.Entity;
namespace MvcProjee.Controllers
{
    public class SinemaController : Controller
    {
        GeziEntities db = new GeziEntities();
        // GET: Sinema
        public ActionResult Index()
        {
            var deger = db.Table_Sinema.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniSinema()
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
        public ActionResult YeniSinema(Table_Sinema p1)
        {
            var ktg = db.Table_Kategori.Where(m => m.KategoriID == p1.Table_Kategori.KategoriID).FirstOrDefault();
            p1.Table_Kategori = ktg;
            db.Table_Sinema.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SIL(int id)
        {
            var snm = db.Table_Sinema.Find(id);
            db.Table_Sinema.Remove(snm);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SinemaEkle(int id)
        {
            var snm = db.Table_Sinema.Find(id);
            List<SelectListItem> degerler = (from i in db.Table_Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("SinemaEkle", snm);
        }
        public ActionResult Guncelle(Table_Sinema p)
        {
            var snm = db.Table_Sinema.Find(p.SinemaID);
            snm.SinemaAdı = p.SinemaAdı;
            snm.SinemaKonumu = p.SinemaKonumu;
            snm.Sinemaİl = p.Sinemaİl;
            snm.Sinemaİlce = p.Sinemaİlce;
            var ktg = db.Table_Kategori.Where(m => m.KategoriID == p.Table_Kategori.KategoriID).FirstOrDefault();
            snm.Kategori_ID = p.Table_Kategori.KategoriID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}