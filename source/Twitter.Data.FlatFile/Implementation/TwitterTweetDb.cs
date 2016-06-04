using System;
using System.Collections.Generic;
using System.Linq;
using Twitter.Core.Config;
using Twitter.Data.FlatFile.Entities;
using Twitter.Data.FlatFile.Interfaces;

namespace Twitter.Data.FlatFile.Implementation
{
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

        public IEnumerable<TweetDto> GetTweets()
        {
            var tweets = GetUsersAndTweets().ToList();

            return tweets.Select((tweet, i) => new TweetDto
            {
                Name = tweet.Key, Order = i, Message = tweet.Value
            });
        }

        public IEnumerable<KeyValuePair<string, string>> GetUsersAndTweets()
        {
            var usersAndTweets = new List<KeyValuePair<string, string>>();
            var lines = _fileDataReader.GetFileData(ConfigurationSettings.TweetsDataFilePathKey);

            foreach (var line in lines.Select(l => l.Split(new[] { UserTweetSeparator }, StringSplitOptions.RemoveEmptyEntries)))
            {
                var name = line[Field.Name];
                var tweet = line[Field.Tweet];

                usersAndTweets.Add(new KeyValuePair<string, string>(name, tweet));
            }

            return usersAndTweets;
        }

        internal static class Field
        {
            public static int Name = 0, Tweet = 1;
        }
    }
}