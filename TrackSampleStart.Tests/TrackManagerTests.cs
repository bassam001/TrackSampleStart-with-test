using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrackSampleStart.Domain;
using TrackSampleStart.DomainServices;
using TrackSampleStart.Shared;

namespace TrackSampleStart.Tests
{
    [TestClass]
    public class TrackManagerTests
    {
        [TestMethod]
        public void MorningSessionContains4AfternoonSessionContains2Tracks()
        {
            var trackManager = TrackManager.Instance;
            trackManager.ClearTracks();

            trackManager.AddTalk(new Talk { Duration = new System.TimeSpan(0, 60, 0) });
            trackManager.AddTalk(new Talk { Duration = new System.TimeSpan(0, 45, 0) });
            trackManager.AddTalk(new Talk { Duration = new System.TimeSpan(0, 30, 0) });
            trackManager.AddTalk(new Talk { Duration = new System.TimeSpan(0, 45, 0) });
            trackManager.AddTalk(new Talk { Duration = new System.TimeSpan(0, 45, 0) });
            trackManager.AddTalk(new Talk { Duration = new System.TimeSpan(0, 60, 0) });

            var tracks = trackManager.GetTracks();
            var track = tracks.First();

            Assert.AreEqual(
                track
                    .Sessions
                    .Single(t => t.DayPart.Equals(DayPart.Morning))
                    .Talks
                    .Count()
                , 4
            );

            Assert.AreEqual(
                track
                    .Sessions
                    .Single(t => t.DayPart.Equals(DayPart.Afternoon))
                    .Talks
                    .Count()
                , 2
            );
        }

        [TestMethod]
        public void MorningSession180Minutes()
        {
            var trackManager = TrackManager.Instance;
            trackManager.ClearTracks();

            trackManager.AddTalk(new Talk { Title = "Dummy 90", Duration = new System.TimeSpan(0, 90, 0) });
            trackManager.AddTalk(new Talk { Title = "Dummy 90", Duration = new System.TimeSpan(0, 90, 0) });
            trackManager.AddTalk(new Talk { Title = "Dummy 30", Duration = new System.TimeSpan(0, 30, 0) });
            trackManager.AddTalk(new Talk { Title = "Dummy 90", Duration = new System.TimeSpan(0, 90, 0) });
            trackManager.AddTalk(new Talk { Title = "Dummy 110", Duration = new System.TimeSpan(0, 110, 0) });
            trackManager.AddTalk(new Talk { Title = "Dummy 10", Duration = new System.TimeSpan(0, 10, 0) });
            trackManager.AddTalk(new Talk { Title = "Dummy 60", Duration = new System.TimeSpan(0, 15, 0) });

            var tracks = trackManager.GetTracks();
            var track1 = tracks.First();

            Assert.AreEqual(
                track1
                    .Sessions
                    .Single(t => t.DayPart.Equals(DayPart.Morning))
                    .Talks
                    .TotalMinutes()
                , 180
            );
        }
    }
}