using Newtonsoft.Json.Serialization;
using ProjectTrackingServices.DependencyResolution;
using ProjectTrackingServices.Models;
using ProjectTrackingServices.Repository;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.WebApi;
using Unity.Injection;
using Unity.Lifetime;

namespace ProjectTrackingServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            IContainer container = IoC.Initialize();
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapWebApiDependencyResolver(container);


            //Dependency injection configuration
            //UnityContainer container = new UnityContainer();
            //container.RegisterType<IProjectsRepository, ProjectsRepository>(new HierarchicalLifetimeManager());
            ////container.RegisterType<ProjectTrackingDBEntities>(new InjectionFactory(c => new ProjectTrackingDBEntities()));
            ////container.RegisterType<IProjectsRepository, ProjectsRepository>();
            //config.DependencyResolver = new UnityResolver(container);
            //config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
