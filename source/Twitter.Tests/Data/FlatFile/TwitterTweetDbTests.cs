using System.Linq;
using Moq;
using NUnit.Framework;
using Twitter.Data.FlatFile.Implementation;
using Twitter.Data.FlatFile.Interfaces;

namespace Twitter.Tests.Data.FlatFile
{
    public class TwitterTweetDbTests
    {
        [Test]
        public void StringDataNotInRequiredFormat()
        {
            var returnValue = new[] { "Mike  This is his tweet" };
            var fileDataReaderMock = new Mock<IFileDataReader>();
            fileDataReaderMock.Setup(mock => mock.GetFileData(It.IsAny<string>())).Returns(returnValue);

            var twitterTweetDb = new TwitterTweetDb(fileDataReaderMock.Object);
            twitterTweetDb.GetUsersAndTweets();
        }

        [Test]
        public void StringDataInRequiredFormat()
        {
            var returnValue = new[] { "Mike> This is his tweet" };
            var fileDataReaderMock = new Mock<IFileDataReader>();
            fileDataReaderMock.Setup(mock => mock.GetFileData(It.IsAny<string>())).Returns(returnValue);

            var twitterTweetDb = new TwitterTweetDb(fileDataReaderMock.Object);
            var ret = twitterTweetDb.GetUsersAndTweets().ToList();

            Assert.AreEqual(ret.First().Key, "Mike");
            Assert.AreEqual(ret.First().Value, "This is his tweet");
        }

        [Test]
        public void PaddedTweetsTrimmed()
        {
            var returnValue = new[] { "Mike>  This is his tweet" };
            var fileDataReaderMock = new Mock<IFileDataReader>();
            fileDataReaderMock.Setup(mock => mock.GetFileData(It.IsAny<string>())).Returns(returnValue);

            var twitterTweetDb = new TwitterTweetDb(fileDataReaderMock.Object);
            var ret = twitterTweetDb.GetUsersAndTweets().ToList();

            Assert.AreEqual(ret.First().Key, "Mike");
            Assert.AreEqual(ret.First().Value, "This is his tweet");
        }
    }
}
