using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShareIt.Controllers
{
    public class ScriptsController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            filterContext.HttpContext.Response.ContentType = "text/javascript";
        }

        protected override ViewResult View(string viewName, string masterName, object model)
        {
            return base.View(viewName, "_ScriptsLayout", model);
        }

        public ActionResult bookmarklet()
        {
            return View();
        }

    }
}
