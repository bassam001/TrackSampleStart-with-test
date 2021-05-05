using System;
using FluentAssertions;
using TrackSampleStart.Parsers;
using Xunit;
using TrackSampleStart.Domain;

namespace TrackSampleStart.Tests
{ 
    public  class ParserTests :IClassFixture<SharedContainerFixture>
    {
        private SharedContainerFixture _container;
        private IParser _parser;
        private Talk _talk;
        private Talk _lightningTalk;
        
        public ParserTests(SharedContainerFixture container)
        {
             _container = container;
             _parser = _container.SharedWindsorContainer.Resolve<IParser>();
             _lightningTalk = new Talk { Title = "Rails for Python Developers lightning" };
             _talk = new Talk { Title = "Lua for the Masses 30min"};
        }

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