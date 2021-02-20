using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace enesatac_site.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [Route("sayfa-bulunamadi")]
        public ActionResult Index()
        {
            return View();
        }
    }
}