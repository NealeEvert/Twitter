using System.Collections.Generic;
using Twitter.Core.Config;
using Twitter.Data.Entities;
using Twitter.Data.Interfaces;

namespace Twitter.Data.Implementations
{
    public class TwitterRepository : ITwitterRepository
    {
        private readonly ITwitterDb _twitterDb;

        public TwitterRepository()
        {
            _twitterDb = Factory.Resolve<ITwitterDb>();
        }

        public TwitterRepository(ITwitterDb twitterDb)
        {
            _twitterDb = twitterDb;
        }

        public IEnumerable<User> GetUsers()
        {
            return _twitterDb.GetTwitterUsersAndTweets();
        }
    }
}