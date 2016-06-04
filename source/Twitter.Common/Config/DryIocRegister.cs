using DryIoc;
using Twitter.Core;
using Twitter.Core.Implementation;
using Twitter.Data.FlatFile.Implementation;
using Twitter.Data.FlatFile.Interfaces;
using Twitter.Data.Implementations;
using Twitter.Data.Interfaces;

namespace Twitter.Common.Config
{
    public class DryIocRegister
    {
        public static void Configure(Container container)
        {
            //Register interfaces for FlatFile Data
            container.Register(typeof(IFileDataReader), typeof(FileDataReader));
            container.Register(typeof(ITwitterTweetDb), typeof(TwitterTweetDb));
            container.Register(typeof(ITwitterUserDb), typeof(TwitterUserDb));

            //Register interfaces for Core
            container.Register(typeof(ITwitterDb), typeof(TwitterDb));
            container.Register(typeof(ITwitterRepository), typeof(TwitterRepository));
            container.Register(typeof(IConfigurationManager), typeof(ConfigurationManager));
        }
    }
}
