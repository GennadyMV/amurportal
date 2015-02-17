using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace amurportal.Controllers
{
    public class AjaxController : Controller
    {
        //
        // GET: /Ajax/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hello()
        {
            Hydro.HydroService theHydro = new Hydro.HydroService();
            string ss = theHydro.Hello("test");
            ViewBag.ss = ss;
            return View();               
        }

        public ActionResult GetSiteTypes()
        {
            Hydro.HydroService theHydro = new Hydro.HydroService();
            Hydro.SiteType[] theSiteTypes = theHydro.GetSiteTypes();

            ViewBag.SiteTypes = theSiteTypes;
            return View();
        }

        public ActionResult GetSites()
        {
            Hydro.HydroService theHydro = new Hydro.HydroService();
            
            return View();
        }
    }
}
