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
    
    public class HomeController : Controller
    {
        EnesAtac_DBEntities db = new EnesAtac_DBEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var listele = db.Articles.OrderByDescending(x => x.Article_Date).ToPagedList(sayfa, 6);
            return PartialView(listele);
        }

               
    }
}