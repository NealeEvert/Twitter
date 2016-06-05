using DryIoc;
using Twitter.Console.Logic.Implementation;
using Twitter.Console.Logic.Interfaces;
using Twitter.Core;
using Twitter.Core.Implementation;
using Container = DryIoc.Container;

namespace Twitter.Console.Logic.Config
{
    public static class Factory
    {
        private static Container _container;

        internal static Container Container
        {
            get
            {
                if (_container != null) return _container;

                _container = new Container(rules => rules.With(FactoryMethod.ConstructorWithResolvableArguments));
                ConfigureContainer(_container);

                return _container;
            }
        }

        private static void ConfigureContainer(IRegistrator container)
        {
            container.Register(typeof(ITwitterPrinter), typeof(TwitterPrinter));
            container.Register(typeof(ITwitterDataCollector), typeof(TwitterDataCollector));
            container.Register(typeof(IConfigurationManager), typeof(ConfigurationManager));
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
