using System.Collections.Generic;
using Twitter.Data.Entities;

namespace Twitter.Data.Interfaces
{
    public interface ITwitterDb
    {
        IEnumerable<User> GetTwitterUsersAndTweets();
    }
}
