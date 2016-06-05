using Moq;
using NUnit.Framework;
using Twitter.Data.FlatFile.Implementation;
using Twitter.Data.FlatFile.Interfaces;

namespace Twitter.Tests.Data.FlatFile
{
    [TestFixture]
    public class TwitterUserDbTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Initialize();
        }

        [Test]
        public void StringDataNotInRequiredFormat()
        {
            var returnValue = new[] { "Mike  John" };
            var fileDataReaderMock = new Mock<IFileDataReader>();
            fileDataReaderMock.Setup(mock => mock.GetFileData(It.IsAny<string>())).Returns(returnValue);

            var twitterUserDb = new TwitterUserDb(fileDataReaderMock.Object);
            twitterUserDb.GetUsersAndFollowers();
        }
        [Test]
        public void HandleEmptyFile()
        {
            var returnValue = new string[0];
            var fileDataReaderMock = new Mock<IFileDataReader>();
            fileDataReaderMock.Setup(mock => mock.GetFileData(It.IsAny<string>())).Returns(returnValue);

            var twitterUserDb = new TwitterUserDb(fileDataReaderMock.Object);
            var ret = twitterUserDb.GetUsersAndFollowers();

            Assert.AreEqual(ret.Count, 0);
        }

        [Test]
        public void StringDataInRequiredFormat()
        {
            var returnValue = new [] { "Mike follows John" };
            var fileDataReaderMock = new Mock<IFileDataReader>();
            fileDataReaderMock.Setup(mock => mock.GetFileData(It.IsAny<string>())).Returns(returnValue);

            var twitterUserDb = new TwitterUserDb(fileDataReaderMock.Object);
            twitterUserDb.GetUsersAndFollowers();
            var ret = twitterUserDb.GetUsersAndFollowers();

            Assert.AreEqual(ret["Mike"].Count, 1);
        }

        [Test]
        public void MultipleFollowingUsers()
        {
            var returnValue = new[] { "Mike follows John,Rob" };
            var fileDataReaderMock = new Mock<IFileDataReader>();
            fileDataReaderMock.Setup(mock => mock.GetFileData(It.IsAny<string>())).Returns(returnValue);

            var twitterUserDb = new TwitterUserDb(fileDataReaderMock.Object);
            var ret = twitterUserDb.GetUsersAndFollowers();

            Assert.AreEqual(ret["Mike"].Count, 2);
        }

        [Test]
        public void MultipleFollowingUsersPaddedRemoved()
        {
            var returnValue = new[] { "Mike follows John, Rob" };
            var fileDataReaderMock = new Mock<IFileDataReader>();
            fileDataReaderMock.Setup(mock => mock.GetFileData(It.IsAny<string>())).Returns(returnValue);

            var twitterUserDb = new TwitterUserDb(fileDataReaderMock.Object);
            var ret = twitterUserDb.GetUsersAndFollowers();

            Assert.AreEqual(ret["Mike"][1], "Rob");
            Assert.AreNotEqual(ret["Mike"][1], " Rob");
        }

        [Test]
        public void PaddedNamesTrimmed()
        {
            var returnValue = new[] { "   Mike  follows  John   " };
            var fileDataReaderMock = new Mock<IFileDataReader>();
            fileDataReaderMock.Setup(mock => mock.GetFileData(It.IsAny<string>())).Returns(returnValue);

            var twitterUserDb = new TwitterUserDb(fileDataReaderMock.Object);
            var ret = twitterUserDb.GetUsersAndFollowers();

            Assert.IsTrue(ret.ContainsKey("Mike"));
            Assert.IsFalse(ret.ContainsKey("   Mike "));
            
            Assert.AreEqual(ret["Mike"][0], "John");
            Assert.AreNotEqual(ret["Mike"][0], " John   ");
        }
    }
}
