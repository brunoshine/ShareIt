using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShareIt.Controllers
{
    public class DebugController : Controller
    {
        //
        // GET: /Debug/

        public ActionResult Index()
        {
            var dic = new Dictionary<string, string>();
            foreach (var item in ConfigurationManager.AppSettings.AllKeys)
            {
                dic.Add(item, ConfigurationManager.AppSettings.Get(item));
            }

            ViewBag.appSettings = dic;
            return View();
        }

    }
}
