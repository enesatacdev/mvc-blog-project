using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using enesatac_site.Models;
using System.Web.Mvc;

namespace enesatac_site.Areas.Ens.Controllers
{
    public class HomeController : Controller
    {
        // GET: Ens/Home
        EnesAtac_DBEntities db = new EnesAtac_DBEntities();
        public ActionResult Index()
        {
            var list = db.Articles.ToList();
            ViewBag.ArticleCount = db.Articles.Count();
            ViewBag.CommentCount = db.CommentsSet.Count();
            var lastarticlelikecount = db.Articles.OrderByDescending(m => m.Article_Date).FirstOrDefault().Article_Like_Count.ToString();
            ViewBag.LastArticleLike = lastarticlelikecount;
            return View();

        }

        public PartialViewResult _IndexArticlesGrid()
        {
            var list = db.Articles.OrderByDescending(x=> x.Article_Date).ToList().Take(5);
            return PartialView(list);
        }
    }
}