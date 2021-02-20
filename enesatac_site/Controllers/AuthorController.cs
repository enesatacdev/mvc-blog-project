using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using enesatac_site.Models;
using System.Web.Mvc;

namespace enesatac_site.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        EnesAtac_DBEntities db = new EnesAtac_DBEntities();
        public ActionResult Index()
        {
            return View();
        }

        [Route("yazar/detay/{id}/{param}")]
        public ActionResult Detail(int id, string param)
        {
            var list = db.Authors.FirstOrDefault(x => x.Auther_Id == id);
            return View(list);
        }
    }
}