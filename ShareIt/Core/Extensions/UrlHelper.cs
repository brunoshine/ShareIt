using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShareIt.Core.Extensions
{
    public static class UrlHelperExtensions
    {
        public static string ToPublicUrl(this UrlHelper urlHelper)
        {
            var httpContext = urlHelper.RequestContext.HttpContext;
            var uriBuilder = new UriBuilder
            {
                Host = httpContext.Request.Url.Host,
                Path = "/",
                Port = 80,
                Scheme = "http",
            };

            if (httpContext.Request.IsLocal)
            {
                uriBuilder.Port = httpContext.Request.Url.Port;
            }
            return uriBuilder.Uri.AbsoluteUri;
        }
    }
}