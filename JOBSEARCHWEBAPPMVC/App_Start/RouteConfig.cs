﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JOBSEARCHWEBAPPMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "componylogin",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CLogin", action = "Login_PageLoad", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CRegistration", action = "Reg_PageLoad", id = UrlParameter.Optional }
            );
            
        }
    }
}
