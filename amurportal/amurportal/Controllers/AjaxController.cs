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

        public JsonResult GetSites()
        {
            List<amurportal.Models.Site> theSites = new List<amurportal.Models.Site>();

            Hydro.HydroService theHydro = new Hydro.HydroService();
            Hydro.SiteType[] theSiteTypes = theHydro.GetSiteTypes();
            foreach (var item in theSiteTypes)
            {
                Hydro.Site[] _sites = theHydro.GetSiteList(item.Id, true);
                if (_sites == null) break;
                foreach (var site in _sites)
                {                    
                    amurportal.Models.Site _site = new amurportal.Models.Site();
                    _site.TypeId = item.Id;
                    _site.TypeName = item.Name;
                    _site.TypeNameShort = item.ShortName;
                    _site.Border = site.Border;
                    _site.Comment = site.Comment;                    
                    _site.Id = site.Id;
                    if (site.Lat != null)
                    {
                        _site.Lat = (decimal)site.Lat;
                    }
                    else
                    {
                        _site.Lat = 0;
                    }
                    if (site.Lon != null)
                    {
                        _site.Lon = (decimal)site.Lon;
                    }
                    else
                    {
                        _site.Lon = 0;
                    }

                    _site.Name = site.Name;                    
                    _site.SiteCode = site.SiteCode;
                    _site.SiteId = site.SiteId;
                    _site.UtcOffset = site.UtcOffset;

                    theSites.Add(_site);
                }
            }

            return Json( theSites, JsonRequestBehavior.AllowGet ); 
        }
    }
}
