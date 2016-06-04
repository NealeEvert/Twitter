using DryIoc;

namespace Twitter.Tests
{
    public class BaseTest
    {
        private Container _container;

        protected Container Container
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
            
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}