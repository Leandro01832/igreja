using repositorioEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Site.Models
{
    public class Roteamento
    {
        public string name { get; set; }
        public string url { get; set; }
        public object defaults { get; set; }

        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.MapRoute(
                name: "BemVindo",
                url: "Home/BemVindo",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

    }
}