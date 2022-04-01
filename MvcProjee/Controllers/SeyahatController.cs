using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjee.Models.Entity;
namespace MvcProjee.Controllers
{
    public class SeyahatController : Controller
    {
        GeziEntities db = new GeziEntities();
        // GET: Seyahat
        public ActionResult Index()
        {
            var deger = db.Table_Seyahat.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniSeyahat()
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
        public ActionResult YeniSeyahat(Table_Seyahat p1)
        {
            var ktg = db.Table_Kategori.Where(m => m.KategoriID == p1.Table_Kategori.KategoriID).FirstOrDefault();
            p1.Table_Kategori = ktg;
            db.Table_Seyahat.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var syht = db.Table_Seyahat.Find(id);
            db.Table_Seyahat.Remove(syht);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SeyahatGetir(int id)
        {
            var syht = db.Table_Seyahat.Find(id);
            List<SelectListItem> degerler = (from i in db.Table_Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("SeyahatGetir", syht);
        }
        public ActionResult Guncelle(Table_Seyahat p1)
        {
            var syht = db.Table_Seyahat.Find(p1.SeyahatID);
            syht.SeyahatAdı = p1.SeyahatAdı;
            syht.Seyahat_Konumu = p1.Seyahat_Konumu;
            syht.Seyahat_İl=p1.Seyahat_İl;
            var ktg = db.Table_Kategori.Where(m => m.KategoriID == p1.Table_Kategori.KategoriID).FirstOrDefault();
            syht.Kategori_ID = p1.Table_Kategori.KategoriID;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}