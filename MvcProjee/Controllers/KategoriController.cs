using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjee.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcProjee.Controllers
{
    public class KategoriController : Controller
    {
        GeziEntities db = new GeziEntities();
        // GET: Kategori
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.Table_Kategori.ToList().ToPagedList(sayfa, 4);
           
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(Table_Kategori p1)
        {
            db.Table_Kategori.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var ktg= db.Table_Kategori.Find(id);
            db.Table_Kategori.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.Table_Kategori.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(Table_Kategori p1)
        {
            var ktg = db.Table_Kategori.Find(p1.KategoriID);
            ktg.KategoriAd = p1.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}