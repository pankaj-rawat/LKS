using LKSapi.Interfaces;
using LKSapi.Repositories;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LKSapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "LKSapi/{controller}/{id}"
            );

            config.Routes.MapHttpRoute(
                name: "NewsPosts",
                routeTemplate: "LKSapi/{controller}/{pageSize}/{pageNumber}/{orderBy}",
                defaults: new { orderBy = RouteParameter.Optional }
            );

            UnityContainer container = new UnityContainer();
            container.RegisterType<INewsPostRepository, NewsPostRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new LKSapi.DependencyResolver(container);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();            
        }
    }
}
