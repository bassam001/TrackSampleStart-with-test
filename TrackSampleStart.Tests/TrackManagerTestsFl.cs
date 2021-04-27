using System.Linq;
using FluentAssertions;
using TrackSampleStart.Domain;
using TrackSampleStart.DomainServices;
using TrackSampleStart.Shared;
using Xunit;

namespace TrackSampleStart.Tests
{
    public class TrackManagerTestsFl
    {
        private ITrackManager _trackManager;
        public TrackManagerTestsFl()
        {
            _trackManager = TrackManager.Instance;
            _trackManager.ClearTracks();

            _trackManager.AddTalk(new Talk { Duration = new System.TimeSpan(0, 60, 0) });
            _trackManager.AddTalk(new Talk { Duration = new System.TimeSpan(0, 45, 0) });
            _trackManager.AddTalk(new Talk { Duration = new System.TimeSpan(0, 30, 0) });
            _trackManager.AddTalk(new Talk { Duration = new System.TimeSpan(0, 45, 0) });
            _trackManager.AddTalk(new Talk { Duration = new System.TimeSpan(0, 45, 0) });
            _trackManager.AddTalk(new Talk { Duration = new System.TimeSpan(0, 60, 0) });
        }

        [Fact]
        public void Track_should_has_two_sesstions()
        {
            var tracks = _trackManager.GetTracks();
            var track = tracks.First();
            track.Sessions.Count.Should().Be(2);

        }

        [Fact]
        public void First_session_should_be_morning()
        {
            var tracks = _trackManager.GetTracks();
            var track = tracks.First();
            track.Sessions.First().DayPart.Should().Be(DayPart.Morning);
        }

    }
}
