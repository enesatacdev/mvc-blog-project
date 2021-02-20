using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using enesatac_site.Models;
using System.Web.Mvc;

namespace enesatac_site.Areas.Ens.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Ens/Category
        EnesAtac_DBEntities db = new EnesAtac_DBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            var silinicekKategori = db.Categorys.Find(id);
            db.Categorys.Remove(silinicekKategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ktgr = db.Categorys.Find(id);
            return View("Edit", ktgr);
        }

        [HttpPost]
        public ActionResult Edit(Categorys parametre)
        {
            var ktgr = db.Categorys.Find(parametre.Category_Id);
            ktgr.Category_Name = parametre.Category_Name.ToString();
            ktgr.Category_Ranking = Convert.ToInt32(parametre.Category_Ranking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCategory(Categorys addParam)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            db.Categorys.Add(addParam);
            db.SaveChanges();
            addParam = null;
            return RedirectToAction("Index");
        }

        public PartialViewResult _CategoryGrid()
        {
            var list = db.Categorys.ToList();
            return PartialView(list);
        }
    }
}