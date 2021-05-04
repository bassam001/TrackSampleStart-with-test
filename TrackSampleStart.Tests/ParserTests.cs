using System;
using Castle.Windsor;
using FluentAssertions;
using TrackSampleStart.Parsers;
using Xunit;
using TrackSampleStart.Domain;

namespace TrackSampleStart.Tests
{ 
    public  class ParserTests
    {
        private IParser _parser;
        private IWindsorContainer _container;
        private Talk _talk;
        private Talk _lightningTalk;
        
        public ParserTests()
        {
            _container = new WindsorContainer();
            _container.Install(new ServicesInstaller());
            _parser = _container.Resolve<IParser>();
            _lightningTalk = new Talk { Title = "Rails for Python Developers lightning" };
             _talk = new Talk { Title = "Lua for the Masses 30min"};
        }

        public void Act()
        { 
            _talk.Duration= _parser.MinuteParser(_talk.Title);
           _lightningTalk.Duration = _parser.LightningParser((_lightningTalk.Title));

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