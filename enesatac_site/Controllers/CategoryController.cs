using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using enesatac_site.Models;

namespace enesatac_site.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        EnesAtac_DBEntities db = new EnesAtac_DBEntities();
        public ActionResult Index()
        {
            return View();
        }

        [Route("kategori/liste/{id}/{param}")]
        public ActionResult List(int id,string param, int sayfa = 1)
        {
            var list = db.Articles.Where(x => x.Category_Id == id).ToList().ToPagedList(sayfa,6);
            if(list.Count < 0)
            {
                ViewBag.IsNull = "block";
            }
            else
            {
                ViewBag.IsNull = "none";
            }
            var categoryName = db.Categorys.Where(x => x.Category_Id == id).Select(x => x.Category_Name).FirstOrDefault();
            ViewBag.CategoryName = categoryName;
            return View(list);
        }
        
    }
}