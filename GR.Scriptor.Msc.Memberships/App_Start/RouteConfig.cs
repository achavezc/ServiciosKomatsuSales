using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Viatecla.Factory.Scriptor.ModularSite.Models;
using Viatecla.Factory.Web.Core;

namespace GR.Scriptor.Msc.Memberships
{
    public class RouteConfig
    {
       
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
               name: "ModuloSeguridadGR",
               url: "ModuloSeguridadGR/{action}/{id}",
               defaults: new { controller = "ModuloSeguridadGR", action = "Index", id = UrlParameter.Optional }
           );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}