using System.Web.Http;
using System.Reflection;
using System.Collections.Generic;
using Tungsten.Services.Interfaces;
using Tungsten.Services;
using Tungsten.HttpRequests.Interfaces;
using Tungsten.HttpRequests.Concetes;
using Tungsten.DataAccess.Interfaces;
using Tungsten.DataAccess.Concretes;
using Microsoft.Practices.Unity;
using WebApiContrib.IoC.Unity;

namespace TungstenRssFeeds.AppStart
{
    public static class UnityConfig
    {
        public static void Register(HttpConfiguration config)
        {

            IUnityContainer container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ITungstenHttpRequest, TungstenRequester>();
            container.RegisterType<IRssService, TungstenRssServices>();
            container.RegisterType<IRssFeedRepository, TungstenRssFeedsRepository>();

            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var t in types)
            {
                if (t.IsAssignableFrom(typeof(ApiController)))
                {
                    container.RegisterType(t);
                }
            }
            config.DependencyResolver = new UnityResolver(container);

        }
    }
}