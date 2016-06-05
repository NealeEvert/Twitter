using System.Collections.Generic;
using Twitter.Core.Config;
using Twitter.Data.Interfaces;
using Twitter.Data.SharedEntities.Entities;

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