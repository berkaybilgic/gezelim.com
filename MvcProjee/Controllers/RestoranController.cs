using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjee.Models.Entity;

namespace MvcProjee.Controllers
{
    public class RestoranController : Controller
    {
        GeziEntities db = new GeziEntities();
        // GET: Restoran
        public ActionResult Index()
        {
            var deger = db.TableRestorant.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniRestoran()
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
        public ActionResult YeniRestoran(TableRestorant p1)
        {
            var ktg = db.Table_Kategori.Where(m => m.KategoriID == p1.Table_Kategori.KategoriID).FirstOrDefault();
            p1.Table_Kategori = ktg;

            db.TableRestorant.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SIL(int id)
        {
            var rstr = db.TableRestorant.Find(id);
            db.TableRestorant.Remove(rstr);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult RestoranGetir(int id)
        {
            var rest= db.TableRestorant.Find(id);
            List<SelectListItem> degerler = (from i in db.Table_Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("RestoranGetir", rest);
        }
        public ActionResult Guncelle(TableRestorant p)
        {
            var rest = db.TableRestorant.Find(p.RestorantID);
            rest.RestorantAdı = p.RestorantAdı;
            rest.RestorantKonumu = p.RestorantKonumu;
            rest.Restorantİl = p.Restorantİl;
            rest.Restorantİlce=p.Restorantİlce;
            var ktg = db.Table_Kategori.Where(m => m.KategoriID == p.Table_Kategori.KategoriID).FirstOrDefault();
            rest.Kategori_ID = p.Table_Kategori.KategoriID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}