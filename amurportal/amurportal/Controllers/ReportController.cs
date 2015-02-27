using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using amurportal.Hydro;

namespace amurportal.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetReportAgk08(string date_report)
        {
            const int TYPE_AGK_SITE = 6;
            const int srocUTC = 8;
            const int variableId = 2;
            const int variableId22 = 22;

            DateTime utcBeginDate = DateTime.ParseExact(date_report + " 00:00:00", "dd.MM.yyyy H:mm:ss", new CultureInfo("en-US"));
            DateTime utcEndDate = DateTime.ParseExact(date_report + " 23:59:59", "dd.MM.yyyy H:mm:ss", new CultureInfo("en-US"));
            
            Hydro.HydroService theHydro = new HydroService();
            Hydro.Site[] _sites = theHydro.GetSiteList(TYPE_AGK_SITE, true);
            ViewBag.Sites = _sites;

            Dictionary<int, List<Hydro.DataValue>> SiteDataValues = new Dictionary<int, List<Hydro.DataValue>>();
            Dictionary<int, List<Hydro.DataValue>> SiteDataValues22 = new Dictionary<int, List<Hydro.DataValue>>();

            if (_sites != null)
            {
                foreach (var theSite in _sites)
                {
                    Hydro.DataValue[] theDataValues = theHydro.GetDataValuesForReport(theSite.SiteId, true,
                                                utcBeginDate, true,
                                                utcEndDate, true,
                                                variableId, true,
                                                srocUTC, true,
                                                null, true,
                                                null, true,
                                                null, true);
                    List<Hydro.DataValue> theList = new List<DataValue>();
                    SiteDataValues.Add(theSite.SiteId, theList);
                    if (theDataValues == null)
                    {
                        continue;
                    }
                    
                    foreach (var datavalue in theDataValues)
                    {
                        theList.Add(datavalue);
                    }
                    SiteDataValues[theSite.SiteId] = theList;
                }                

                ViewBag.SiteDataValues = SiteDataValues;

                foreach (var theSite in _sites)
                {
                    Hydro.DataValue[] theDataValues = theHydro.GetDataValuesForReport(theSite.SiteId, true,
                                                utcBeginDate, true,
                                                utcEndDate, true,
                                                variableId22, true,
                                                srocUTC, true,
                                                null, true,
                                                null, true,
                                                null, true);
                    List<Hydro.DataValue> theList = new List<DataValue>();
                    SiteDataValues22.Add(theSite.SiteId, theList);
                    if (theDataValues == null)
                    {
                        continue;
                    }
                    
                    foreach (var datavalue in theDataValues)
                    {
                        theList.Add(datavalue);
                    }
                    SiteDataValues22[theSite.SiteId] = theList;
                }                
            

            }

            

            ViewBag.SiteDataValues = SiteDataValues;
            ViewBag.SiteDataValues22 = SiteDataValues22;

            return View();
        }

    }
}
