using System.Collections.Generic;
using Twitter.Data.Shared.Entities;

namespace Twitter.Data.Interfaces
{
    public interface ITwitterDb
    {
        IEnumerable<User> GetTwitterUsersAndTweets();
    }
}
