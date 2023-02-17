﻿using API.PruebasPolly.NF452.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API.PruebasPolly.NF452
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API
            config.DependencyResolver = new UnityResolver(DependencyResolver.DIContainer());

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
