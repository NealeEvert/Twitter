using System.Collections.Generic;
using System.Linq;
using System.Net;
using Twitter.Console.Logic.Config;
using Twitter.Console.Logic.Interfaces;
using Twitter.Data.Shared.Entities;

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
            var output = new List<string>();

            try
            {
                var users = _twitterDataCollector.GetTwitterFeed();

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
            }
            catch (WebException ex)
            {
                output.Add(ex.Message);
            }

            return output;
        }
    }
}
