using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using TrackSampleStart.Parsers;
using Xunit;

namespace TrackSampleStart.Tests.FixtureTest
{
   public class WindsorContainerTest: IClassFixture<SharedContainerFixture>
    {
        private SharedContainerFixture _container;

        public WindsorContainerTest(SharedContainerFixture container)
        {
            _container = container;
        }

        [Fact]
        public void Container_should_return_all_IParser_implementations()
        {
            _container.SharedWindsorContainer.ResolveAll<IParser>().Count().Should().Be(2);
        }
    }
}