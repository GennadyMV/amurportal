using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using amurportal.Hydro;

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

        public ActionResult GetSiteParams(int SiteId)
        {
            Hydro.HydroService theHydro = new Hydro.HydroService();
            
            Hydro.Site[] _sites = theHydro.GetSiteList(null, true);

            if (_sites != null)
            {
                foreach (var site in _sites)
                {
                    if (site.SiteId == SiteId)
                    {
                        Models.Site theSite = new Models.Site(site);
                        return View(theSite);
                    }
                }
            }
            
            return View();
        }

        public JsonResult GetSites()
        {
            List<amurportal.Models.Site> theSites = new List<amurportal.Models.Site>();

            Hydro.HydroService theHydro = new Hydro.HydroService();
            Hydro.Site[] _sites = theHydro.GetSiteList(null, true);

            if (_sites != null)
            {
                foreach (var site in _sites)
                {
                    amurportal.Models.Site _site = new amurportal.Models.Site(site);

                    theSites.Add(_site);
                }
            }

            return Json( theSites, JsonRequestBehavior.AllowGet ); 
        }
    }
}
