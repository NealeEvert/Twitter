using System.Collections.Generic;
using Twitter.Data.FlatFile.Entities;

namespace Twitter.Data.FlatFile.Interfaces
{
    /// <summary>
    /// Twitter Tweet Database Context
    /// </summary>
    public interface ITwitterTweetDb
    {
        /// <summary>
        /// Get all tweets in the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<TweetDto> GetTweets();

        /// <summary>
        /// Get a list of users and their combined tweets
        /// </summary>
        /// <returns>KeyValuePair of users with all their tweets</returns>
        IEnumerable<KeyValuePair<string, string>> GetUsersAndTweets();
    }
}
