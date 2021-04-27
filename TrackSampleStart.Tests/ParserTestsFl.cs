using System;
using FluentAssertions;
using TrackSampleStart.Parsers;
using Xunit;
using Moq;
using TrackSampleStart.Repository;

namespace TrackSampleStart.Tests
{ 
    public  class ParserTestsFl
    {


         [Fact]
        public void It_should_parse_time()
        {
            var dep = new Mock<ITestRepository>().Object;

            var parsing = new TalkParser();
            var result = parsing.Time(dep.GetFakeData());
            parsing.Success.Should().Be(true);
            result.Should().Be(new TimeSpan(00,15,00));
        }

        [Fact]
        public void It_should_get_lightning_duration()
        {
            var data = "Rails for Python Developers lightning";
            var readingLightning = new LightningParser();
            var lightningDuration = readingLightning.Time(data);

            readingLightning.Success.Should().Be(true);
            lightningDuration.Should().Equals(5);
        }
    }
}