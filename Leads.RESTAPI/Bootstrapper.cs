using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Leads.Core;
using Serilog;
using System;
using System.Web.Http;
using System.Web.Mvc;

namespace Leads.RESTAPI
{
    public class Bootstrapper
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance<ILogger>(Log.Logger); //Serilog registration
            builder.RegisterApiControllers(typeof(Controllers.LeadsController).Assembly); //For API Controllers
            builder.RegisterControllers(typeof(Controllers.LeadsController).Assembly); //For MVC Controllers
            builder.RegisterType<LeadsService>().As<ILeadsService>().SingleInstance(); //LeadsService business logic
            builder.RegisterType<LeadsReportService>().As<ILeadsReportService>().SingleInstance();
            builder.RegisterType<NotificationService>().As<INotificationService>().SingleInstance();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //DI resolver for MVC
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //DI resolver for Web API
        }
    }
}