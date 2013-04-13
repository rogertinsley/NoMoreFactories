using System;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using NoMoreFactories.Controllers;
using Unity.Mvc3;

namespace NoMoreFactories
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<Func<string, ICar>>(new InjectionFactory(
                ctx => new Func<string, ICar>(name => container.Resolve<ICar>(name))));

            container.RegisterType<ICar, Ford>("Ford");
            container.RegisterType<ICar, Volkswagon>("Volkswagon");
            container.RegisterType<ICar, Peugeot>("Peugeot");

            return container;
        }
    }
}