﻿namespace PlacesToEat.Web
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;

    using Controllers;
    using Data;
    using Data.Common;
    using Data.Common.Contracts;
    using Services.Data.Contracts.UserServices;
    using Services.Geo.Contracts;
    using Services.Web;
    using Services.Web.Contracts;
    using Tools.Infrastructure.Contracts;

    public static class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // Register services
            RegisterServices(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.Register(x => new PlacesToEatDbContext())
                .As<DbContext>()
                .InstancePerRequest();
            builder.Register(x => new HttpCacheService())
                .As<ICacheService>()
                .InstancePerRequest();

            var geoAssembly = Assembly.GetAssembly(typeof(IGeoLocatorService));
            builder.RegisterAssemblyTypes(geoAssembly).AsImplementedInterfaces();

            var userServicesAssembly = Assembly.GetAssembly(typeof(IUserService));
            builder.RegisterAssemblyTypes(userServicesAssembly).AsImplementedInterfaces();

            var toolsInfrastructureAssembly = Assembly.GetAssembly(typeof(IUtilities));
            builder.RegisterAssemblyTypes(toolsInfrastructureAssembly).AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(DbRepository<>))
                .As(typeof(IDbRepository<>))
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(DbUserRepository<>))
                .As(typeof(IDbUserRepository<>))
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<BaseController>().PropertiesAutowired();
        }
    }
}
