using E_Commerce.Models;
using E_Commerce.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace E_Commerce
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<CartDbAccessService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}