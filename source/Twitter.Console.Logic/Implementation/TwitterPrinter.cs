using System.Collections.Generic;
using System.Linq;
using Twitter.Console.Logic.Config;
using Twitter.Console.Logic.Interfaces;

namespace Twitter.Console.Logic.Implementation
{
    public class TwitterPrinter : ITwitterPrinter
    {
        private readonly ITwitterDataCollector _twitterDataCollector;

        public TwitterPrinter()
        {
            _twitterDataCollector = Factory.Resolve<ITwitterDataCollector>();
        }

        public TwitterPrinter(ITwitterDataCollector twitterDataCollector)
        {
            _twitterDataCollector = twitterDataCollector;
        }

        public IList<string> PrintFeed()
        {
            var users = _twitterDataCollector.GetTwitterFeed();
            var output = new List<string>();
            foreach (var user in users.OrderBy(u => u.Name))
            {
                output.Add(user.Name);
                output.Add(string.Empty);
                var allTweets = user.Follows?.SelectMany(f => f.Tweets).Union(user.Tweets);

                if (allTweets == null) continue;
                foreach (var tweet in allTweets.OrderBy(t => t.Order))
                {
                    output.Add($"@{tweet.Name}: {tweet.Message}");
                    output.Add(string.Empty);
                }
            }

            return output;
        }
    }
}
