using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using amurportal.Hydro;
using System.Globalization;

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

        public ActionResult GetAllDataValue(int SiteId, string utcDateDDMMYYYY)
        {
            Hydro.HydroService theHydro = new HydroService();
            DateTime utcDateBgn = DateTime.ParseExact(utcDateDDMMYYYY + " 00:00:00", "ddMMyyyy H:mm:ss", new CultureInfo("en-US"));
            DateTime utcDateEnd = DateTime.ParseExact(utcDateDDMMYYYY + " 23:59:59", "ddMMyyyy H:mm:ss", new CultureInfo("en-US"));

            Hydro.Site[] _sites = theHydro.GetSiteList(null, true);
            int siteTypeId = 0;
            if (_sites != null)
            {
                foreach (var site in _sites)
                {
                    if (site.SiteId == SiteId)
                    {
                        siteTypeId = site.Type.Id;
                    }
                }
            }

            Hydro.Variable[] theVariables = theHydro.GetSiteTypeVariables(siteTypeId, true);

            Dictionary<string, List<Hydro.DataValue>> dictionary_in = new Dictionary<string, List<Hydro.DataValue>>();
            

            foreach (var variable in theVariables)
            {
                Hydro.DataValue[] theDataValues = theHydro.GetDataValuesForReport(SiteId, true, 
                                                                utcDateBgn, true,
                                                                utcDateEnd, true,
                                                                variable.Id, true,
                                                                1, true,
                                                                null, true,
                                                                null, true, 
                                                                null, true);
                if (theDataValues == null) continue;
                List<Hydro.DataValue> theDataValuesList = new List<Hydro.DataValue>();
                foreach (var value in theDataValues)
                {
                    theDataValuesList.Add(value);
                }
                dictionary_in.Add(variable.Name, theDataValuesList);                
            }
            ViewBag.Variables = theVariables;
            ViewBag.dictionary_in = dictionary_in;            
            return View();
        }

        public ActionResult GetSiteTypeVariables(int siteTypeId)
        {
            Hydro.HydroService theHydro = new HydroService();
            Hydro.Variable[] theVariables = theHydro.GetSiteTypeVariables(siteTypeId, true);
            return View();
        }
    }
}
