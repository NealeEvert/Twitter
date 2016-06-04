using System.Web.Http;

namespace Twitter.Core.Config
{
    public static class Factory
    {
        public static T Resolve<T>()
        {
            var ret = (T)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(T));
            return ret;
        }
    }
}
