using Autofac;
using Autofac.Integration.Mvc;
using Hitay.Business.Infastructure;
using System.Web.Mvc;

namespace Hitay.API.App_Start
{
    public static class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = IoC.Builder;
            builder.RegisterControllers(typeof(WebApiApplication).Assembly).PropertiesAutowired();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(IoC.CreateContainer()));
        }
    }
}