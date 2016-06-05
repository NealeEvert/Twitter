using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Twitter.Data.FlatFile.Entities;
using Twitter.Data.FlatFile.Implementation;
using Twitter.Data.FlatFile.Interfaces;

namespace Twitter.Tests.Data
{
    [TestFixture]
    public class TwitterDbTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Initialize();
        }

        [Test]
        public void AddingUsersWithoutFollowing()
        {
            var returnValue1 = new List<UserDto>
            {
                new UserDto { Name = "Mike", Follows = new List<string> { "John" } },
                new UserDto { Name = "John" }
            };

            var twitterUserDb = new Mock<ITwitterUserDb>();
            twitterUserDb.Setup(mock => mock.GetUsers()).Returns(returnValue1);

            var returnValue2 = new List<TweetDto> { new TweetDto { Name = "Mike", Message = "This is a tweet", Order = 1} };
            var twitterTweetDb = new Mock<ITwitterTweetDb>();
            twitterTweetDb.Setup(mock => mock.GetTweets()).Returns(returnValue2);

            var twitterDb = new TwitterDb(twitterUserDb.Object, twitterTweetDb.Object);
            var ret = twitterDb.GetTwitterUsersAndTweets().ToArray();

            Assert.IsTrue(ret.Any(r => r.Name.Equals("Mike")));
            Assert.IsTrue(ret.Any(r => r.Tweets.Any(t => t.Message.Equals("This is a tweet"))));
            Assert.IsTrue(ret.Any(r => r.Follows.Any(f => f.Name.Equals("John"))));
        }
    }
}
