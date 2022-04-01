using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjee.Models.Entity;


namespace MvcProjee.Controllers
{
    public class AvmController : Controller
    {
        GeziEntities db = new GeziEntities();
        // GET: Avm
        public ActionResult Index()
        {
            var degerler = db.Table_AVM.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniAvm()
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
        public ActionResult YeniAvm(Table_AVM p1)
        {
            var ktg = db.Table_Kategori.Where(m => m.KategoriID == p1.Table_Kategori.KategoriID).FirstOrDefault();
            p1.Table_Kategori = ktg;

            db.Table_AVM.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var avm = db.Table_AVM.Find(id);
            db.Table_AVM.Remove(avm);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult GUNCELLE(int id)
        {
            var avm = db.Table_AVM.Find(id);
            List<SelectListItem> degerler = (from i in db.Table_Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("GUNCELLE",avm);
        }
        public ActionResult AvmGetir(Table_AVM p1)
        {
            var avm = db.Table_AVM.Find(p1.AvmID);
            avm.AvmAdı = p1.AvmAdı;
            avm.AvmKonumu = p1.AvmKonumu;
            avm.Avmİl = p1.Avmİl;
            avm.Avmİlce = p1.Avmİlce;
            var ktg = db.Table_Kategori.Where(m => m.KategoriID == p1.Table_Kategori.KategoriID).FirstOrDefault();
            avm.Kategori_ID = p1.Table_Kategori.KategoriID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}