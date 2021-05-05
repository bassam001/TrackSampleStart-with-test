﻿using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using TrackSampleStart.Domain;
using TrackSampleStart.DomainServices;
using TrackSampleStart.Shared;
using Xunit;

namespace TrackSampleStart.Tests
{
    public class TrackManagerTests : IClassFixture<SharedContainerFixture>
    {
        private SharedContainerFixture _container;
        private ITrackManager _trackManager;
        private List<Track> _tracks;

        public TrackManagerTests(SharedContainerFixture container)
        {
            _container = container;
            _trackManager = _container.SharedWindsorContainer.Resolve<ITrackManager>();
            _trackManager.ClearTracks();

            _trackManager.AddTalk(new Talk { Duration = new System.TimeSpan(0, 60, 0) });
            _trackManager.AddTalk(new Talk { Duration = new System.TimeSpan(0, 45, 0) });
            _trackManager.AddTalk(new Talk { Duration = new System.TimeSpan(0, 30, 0) });
            _trackManager.AddTalk(new Talk { Duration = new System.TimeSpan(0, 45, 0) });
            _trackManager.AddTalk(new Talk { Duration = new System.TimeSpan(0, 45, 0) });
            _trackManager.AddTalk(new Talk { Duration = new System.TimeSpan(0, 60, 0) });
        }

        public void Act()
        {
            _tracks = _trackManager.GetTracks();
        }

        [Fact]
        public void Track_should_has_two_sesstions()
        {
            Act();
            var track = _tracks.First();
            track.Sessions.Count.Should().Be(2);
        }

        [Fact]
        public void First_session_should_be_morning()
        {
            Act();
            var track = _tracks.First();
            track.Sessions.First().DayPart.Should().Be(DayPart.Morning);
        }
    }
}
