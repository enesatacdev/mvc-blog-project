using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using enesatac_site.Models;

namespace enesatac_site.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        EnesAtac_DBEntities db = new EnesAtac_DBEntities();
        public ActionResult Index()
        {
            return View();
        }

        [Route("makale/detay/{id}/{param}")]
        public ActionResult Detail(int id, string param)
        {
            var list = db.Articles.FirstOrDefault(x => x.Article_Id == id);
            ViewBag.MetaKeywords = list.Tags.ToString();
            ViewBag.MetaDescription = list.Tags.ToString();
            return View(list);
        }

        public ActionResult MakeComment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MakeComment(Comments cmnt, int id)
        {
            db.CommentsSet.Add(cmnt);
            db.SaveChanges();
            cmnt = null;
            return View();
        }

        public string Like(int id)
        {
            var list = db.Articles.FirstOrDefault(x=> x.Article_Id == id);
            list.Article_Like_Count++;
            db.SaveChanges();
            return list.Article_Like_Count.ToString();
        }

        public string Viewed(int id)
        {
            var list = db.Articles.FirstOrDefault(x => x.Article_Id == id);
            list.Article_View_Count++;
            db.SaveChanges();
            return list.Article_View_Count.ToString();
        }
        
    }
}