using System;
using FluentAssertions;
using Xunit;

namespace TrackSampleStart.Tests
{
    public class ParserTests : TestBase
    {

        public void Act()
        {
            _talk.Duration = _talkParser.Time(_talk.Title);
            _lightningTalk.Duration = _talkParser.Time((_lightningTalk.Title));
        }

        [Fact]
        public void It_should_parse_talk_duration()
        {
            Act();

            _talk.Duration.Should().Be(new TimeSpan(00, 30, 00));
        }

        [Fact]
        public void It_should_get_lightning_duration()
        {
            Act();

            _lightningTalk.Duration.Should().Be(new TimeSpan(00, 5, 00));

        }
    }
}
