using System.Collections.Generic;
using System.Linq;
using Twitter.Core.Config;
using Twitter.Data.FlatFile.Interfaces;
using Twitter.Data.Interfaces;
using Twitter.Data.Shared.Entities;

namespace Twitter.Data.FlatFile.Implementation
{
    public class TwitterDb : ITwitterDb
    {
        private readonly ITwitterUserDb _twitterUserDb;
        private readonly ITwitterTweetDb _twitterTweetDb;

        public TwitterDb()
        {
            _twitterUserDb = Factory.Resolve<ITwitterUserDb>();
            _twitterTweetDb = Factory.Resolve<ITwitterTweetDb>();
        }

        public TwitterDb(ITwitterUserDb twitterUserDb, ITwitterTweetDb twitterTweetDb)
        {
            _twitterUserDb = twitterUserDb;
            _twitterTweetDb = twitterTweetDb;
        }

        public IEnumerable<User> GetTwitterUsersAndTweets()
        {
            var users = _twitterUserDb.GetUsers().ToList();
            var tweets = _twitterTweetDb.GetTweets().ToList();

            var twitterUsers = users.Select(u => new User
            {
                Name = u.Name,
                Tweets = tweets.Where(t => t.Name.Equals(u.Name)).Select(t => new Tweet {Message = t.Message, Order = t.Order}).ToList()
            }).ToList();

            foreach (var twitterUser in twitterUsers)
            {
                foreach (var tweet in twitterUser.Tweets)
                    tweet.Name = twitterUser.Name;

                var follows = users.First(u => u.Name.Equals(twitterUser.Name)).Follows?.ToArray();
                if (follows != null && follows.Any())
                    twitterUser.Follows = twitterUsers.Where(u => follows.Any(f => f.Equals(u.Name))).ToList();
            }

            return twitterUsers;
        }
    }
}