using FluentAssertions;
using TrackSampleStart.Parsers;
using Xunit;

namespace TrackSampleStart.Tests
{ 
    public  class ParserTestsFl
    {
         [Fact]
        public void It_should_parse_time()
        {
            var data = "Time is given as number in minutes 60min";

            var parsing = new TalkParser();
            var result = parsing.Time(data);
            parsing.Success.Should().Be(true);
            result.Should().Equals(60);
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