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
    public class WidgetController : Controller
    {
        // GET: Widget
        EnesAtac_DBEntities db = new EnesAtac_DBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Sidebar()
        {
            return PartialView();
        }
        public PartialViewResult CategorySidebar()
        {
            var listele = db.Categorys.ToList();
            return PartialView(listele);
        }

        public PartialViewResult LastArticles()
        {
            var listele = db.Articles.OrderByDescending(x => x.Article_Date).Take(5).ToList();
            return PartialView(listele);
        }

        public PartialViewResult TagsSidebar()
        {
            var listele = db.Tags.OrderByDescending(x => x.Tag_Id).Take(10).ToList();
            return PartialView(listele);
        }

        public PartialViewResult HeaderNavigation()
        {
            var listele = db.Categorys.ToList();
            return PartialView(listele);
        }

        public PartialViewResult FooterNavigation()
        {
            var listele = db.Categorys.ToList().Take(8);
            return PartialView(listele);
        }

        public PartialViewResult FooterPopularArticles()
        {
            var listele = db.Articles.OrderByDescending(x => x.Article_View_Count).Take(3);
            return PartialView(listele);
        }

        public PartialViewResult FooterLastArticles()
        {
            var listele = db.Articles.OrderByDescending(x => x.Article_Date).Take(3);
            return PartialView(listele);
        }
        
        public PartialViewResult SliderPictures()
        {
            var listele = db.Sliders.ToList();
            return PartialView(listele);
        }
       
        public PartialViewResult SearchSidebar()
        {
            return PartialView();
        }

        [Route("makale/arama-sonuclari")]
       public ActionResult SearchResults(string param)
        {
            var listele = db.Articles.Where(x => x.Article_Title.ToLower().Contains(param.ToLower())).OrderByDescending(x=> x.Article_Date).ToList();
            return View(listele);
        }

     



    }
}