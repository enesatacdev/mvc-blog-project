using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using enesatac_site.Models;
using System.Web.Mvc;
using System.IO;

namespace enesatac_site.Areas.Ens.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Ens/Article
        EnesAtac_DBEntities db = new EnesAtac_DBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _ArticleListGrid()
        {
            var list = db.Articles.OrderByDescending(x=> x.Article_Date).ToList();
            return PartialView(list);
        }

        public ActionResult Delete(int id)
        {
            var silinicekKategori = db.Articles.Find(id);
            db.Articles.Remove(silinicekKategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ktgr = db.Articles.Find(id);
            ViewBag.CategoryCounter = db.Categorys.Count();
            List<SelectListItem> listbox = (from i in db.Categorys.ToList() select new SelectListItem { Text = i.Category_Name, Value = i.Category_Id.ToString() }).ToList();
            ViewBag.ListBoxValues = listbox;
            return View("Edit", ktgr);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(Articles parametre, HttpPostedFileBase coverimg)
        {
            var article = db.Articles.Find(parametre.Article_Id);
            article.Article_Title = parametre.Article_Title.ToString();
            article.Article_Content = parametre.Article_Content.ToString();
            article.Article_Meta_Tags = parametre.Article_Meta_Tags.ToString();
            article.Article_Meta_Description = parametre.Article_Meta_Description.ToString();

            if (coverimg != null)
            {
                string filename = Path.GetFileNameWithoutExtension(coverimg.FileName);
                string extenson = Path.GetExtension(coverimg.FileName);
                string covername = Path.Combine(Server.MapPath("~/Content/UploadFiles/images/"), filename);
                string fullpath = covername + extenson;
                coverimg.SaveAs(fullpath);
                filename = filename + extenson;
                parametre.Article_Cover_Image = "/Content/UploadFiles/images/" + filename;

                article.Article_Cover_Image = parametre.Article_Cover_Image.ToString();
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult NewArticle()
        {
            var ktgr = db.Articles.ToList();
            ViewBag.CategoryCounter = db.Categorys.Count();
            SelectList slcCategory = new SelectList(db.Categorys.ToList(), "Category_Id", "Category_Name");
            ViewBag.ListBoxValues = slcCategory;
            ViewBag.AuthorCounter = db.Authors.Count();
            SelectList slcAuthor = new SelectList(db.Authors.ToList(), "Auther_Id", "Author_Name");
            ViewBag.AuthorListValues = slcAuthor;
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult NewArticle(Articles addParam,int SelectedCategory, int SelectedAuthor, HttpPostedFileBase coverimg)
        {

            if (coverimg != null)
            {
                string filename = Path.GetFileNameWithoutExtension(coverimg.FileName);
                string extenson = Path.GetExtension(coverimg.FileName);
                string covername = Path.Combine(Server.MapPath("~/Content/UploadFiles/images/"), filename);
                string fullpath = covername + extenson;
                coverimg.SaveAs(fullpath);
                filename = filename + extenson;
                addParam.Article_Cover_Image = "/Content/UploadFiles/images/" + filename;

            }

            var slcCategory = db.Categorys.Where(m => m.Category_Id == SelectedCategory).FirstOrDefault();
            addParam.Categorys = slcCategory;
            var slcAuthor = db.Authors.Where(m => m.Auther_Id == SelectedAuthor).FirstOrDefault();
            addParam.Authors = slcAuthor;
            addParam.Article_Date = DateTime.Now;
            db.Articles.Add(addParam);
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        
    }
}