using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ShareIt.Handlers;

namespace ShareIt
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsHandler()); 

            SetWebAPILogging();
        }

        private void SetWebAPILogging()
        {
            var config = (CustomErrorsSection)ConfigurationManager.GetSection("system.web/customErrors");

            IncludeErrorDetailPolicy errorDetailPolicy;

            switch (config.Mode)
            {
                case CustomErrorsMode.RemoteOnly:
                    errorDetailPolicy
                        = IncludeErrorDetailPolicy.LocalOnly;
                    break;
                case CustomErrorsMode.On:
                    errorDetailPolicy
                        = IncludeErrorDetailPolicy.Never;
                    break;
                case CustomErrorsMode.Off:
                    errorDetailPolicy
                        = IncludeErrorDetailPolicy.Always;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy
                = errorDetailPolicy;
        }
    }
}