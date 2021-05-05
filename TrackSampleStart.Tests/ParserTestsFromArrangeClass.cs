using System;
using FluentAssertions;
using Xunit;

namespace TrackSampleStart.Tests
{
   public class ParserTestsFromArrangeClass : ArrangeClass
    {
        public void Act()
       {
           _talk.Duration = _parser.Time(_talk.Title);
           _lightningTalk.Duration = _parser.Time((_lightningTalk.Title));
       }

        [Fact]
        public void It_should_parse_talk_duration()
        {
            Act();

            _talk.Duration.Should().Be(new TimeSpan(00, 30, 00));
            _parser.Success.Should().Be(true);
        }

        [Fact]
        public void It_should_get_lightning_duration()
        {
            Act();

            _lightningTalk.Duration.Should().Be(new TimeSpan(00, 5, 00));
            _parser.Success.Should().Be(true);
        }
    }
}
