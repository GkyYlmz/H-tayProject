using Autofac;
using Hitay.Business.General;
using Hitay.Data.Model;

namespace Hitay.Business.Infastructure
{
    public static class IoC
    {
        public static ContainerBuilder Builder;
        private static IContainer Container;

        static IoC()
        {
            if (Builder == null)
            {
                Builder = new ContainerBuilder();
                Builder.RegisterType<GeneralService>().As<IGeneralService>();
                Builder.RegisterType<HitayEntities>();
            }
        }

        public static IContainer CreateContainer()
        {
            Container = Builder.Build();
            return Container;
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
