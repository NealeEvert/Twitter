using System.Web.Http;
using DryIoc;
using DryIoc.WebApi;
using Twitter.Core.Implementation;
using Twitter.Core.Interfaces;

namespace Twitter.Tests
{
    public class BaseTest
    {
        private Container _container;

        public void Initialize()
        {
        }

        internal Container Container
        {
            get
            {
                if (_container == null)
                    _container = new Container();

                ConfigureContainer(_container);

                return _container;   
            }
        }

        private void ConfigureContainer(Container container)
        {
            container.Register(typeof(ILogManager), typeof(LogManager));
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}