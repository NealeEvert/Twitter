using System;
using System.Collections.Generic;
using System.Linq;
using Twitter.Core.Config;
using Twitter.Core.Interfaces;
using Twitter.Data.FlatFile.Entities;
using Twitter.Data.FlatFile.Interfaces;

namespace Twitter.Data.FlatFile.Implementation
{
    /// <summary>
    /// Twitter Tweet Database Context
    /// </summary>
    public class TwitterTweetDb : ITwitterTweetDb
    {
        private const string UserTweetSeparator = "> ";

        private readonly IFileDataReader _fileDataReader;

        public TwitterTweetDb()
        {
            _fileDataReader = Factory.Resolve<IFileDataReader>();
        }

        public TwitterTweetDb(IFileDataReader fileDataReader)
        {
            _fileDataReader = fileDataReader;
        }

        /// <summary>
        /// Get all tweets in the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TweetDto> GetTweets()
        {
            var tweets = GetUsersAndTweets().ToList();

            return tweets.Select((tweet, i) => new TweetDto
            {
                Name = tweet.Key, Order = i, Message = tweet.Value
            });
        }
        
        /// <summary>
        /// Get a list of users and their combined tweets
        /// </summary>
        /// <returns>KeyValuePair of users with all their tweets</returns>
        public IEnumerable<KeyValuePair<string, string>> GetUsersAndTweets()
        {
            var usersAndTweets = new List<KeyValuePair<string, string>>();
            var lines = _fileDataReader.GetFileData(ConfigurationSettings.TweetsDataFilePathKey);

            //Data lines that are not properly formed are excluded
            foreach (var line in lines.Where(l => l.Contains(UserTweetSeparator)).Select(l => l.Split(new[] { UserTweetSeparator }, StringSplitOptions.RemoveEmptyEntries)))
            {
                var name = line[Field.Name];
                var tweet = line[Field.Tweet].Trim();

                usersAndTweets.Add(new KeyValuePair<string, string>(name, tweet));
            }

            //Log the lines that aren't formed properly as warnings to the log file
            foreach (var line in lines.Where(l => !l.Contains(UserTweetSeparator)))
                Factory.Resolve<ILogManager>()?.LogWarning($"Line does not contain a separator: {line}");

            return usersAndTweets;
        }

        internal static class Field
        {
            public static int Name = 0, Tweet = 1;
        }
    }
}