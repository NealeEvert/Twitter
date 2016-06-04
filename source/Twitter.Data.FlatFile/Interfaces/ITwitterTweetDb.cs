using System.Collections.Generic;
using Twitter.Data.FlatFile.Entities;

namespace Twitter.Data.FlatFile.Interfaces
{
    public interface ITwitterTweetDb
    {
        IEnumerable<TweetDto> GetTweets();

        IEnumerable<KeyValuePair<string, string>> GetUsersAndTweets();
    }
}
