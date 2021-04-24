using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrackSampleStart.Repository;

namespace TrackSampleStart.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void GetTalksFromRepo()
        {
            var repo = new GetTalkRepository(new System.IO.FileInfo("Data/talks.txt").FullName);
            var talks = repo.GetAll();
            Assert.IsTrue(talks.Count.Equals(3));
        }
    }
}

