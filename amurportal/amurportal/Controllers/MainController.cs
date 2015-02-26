using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace amurportal.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Main/

        public ActionResult Index()
        {
            ViewBag.DateBgn = String.Format("{0:dd.MM.yyyy}", DateTime.Now.AddDays(-30));
            ViewBag.DateEnd = String.Format("{0:dd.MM.yyyy}", DateTime.Now);
            return View();
        }

    }
}
