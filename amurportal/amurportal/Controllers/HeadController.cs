using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace amurportal.Controllers
{
    public class HeadController : Controller
    {
        //
        // GET: /Head/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTypes()
        {
            Hydro.HydroService theHydro = new Hydro.HydroService();
            Hydro.SiteType[] theSiteTypes = theHydro.GetSiteTypes();
            ViewBag.SiteTypes = theSiteTypes;            
            return View();
        }

        public ActionResult GetSites(int TypeId = 0)
        {
            Hydro.HydroService theHydro = new Hydro.HydroService();
            Hydro.Site[] theSites;
            if (TypeId > 0)
            {
                theSites = theHydro.GetSiteList(TypeId, true);
            }
            else
            {
                theSites = theHydro.GetSiteList(null, true);
            }
            ViewBag.Sites = theSites;

            return View();
        }

        public ActionResult GetVariables()
        {
            const int TYPE_AGK = 6;
            Hydro.HydroService theHydro = new Hydro.HydroService();
            Hydro.Variable[] theVariables = theHydro.GetSiteTypeVariables(TYPE_AGK, true);
            ViewBag.Variables = theVariables;
            return View();
        }

    }
}
