using System.Collections.Generic;
using Twitter.Data.SharedEntities.Entities;

namespace Twitter.Data.Interfaces
{
    public interface ITwitterDb
    {
        IEnumerable<User> GetTwitterUsersAndTweets();
    }
}
