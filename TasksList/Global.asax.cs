﻿using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TasksList.Models;
using TasksList.Utils;

namespace TasksList
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer(new DataInitializer());

            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            var prov = ModelValidatorProviders.Providers;
            if (ModelValidatorProviders.Providers.OfType<DataAnnotationsModelValidatorProvider>().FirstOrDefault() != null)
                prov.Remove(ModelValidatorProviders.Providers.OfType<DataAnnotationsModelValidatorProvider>().First());
        }
    }
}
