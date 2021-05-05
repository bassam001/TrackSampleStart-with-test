using System.Collections.Generic;
using TrackSampleStart.Repository;
using FluentAssertions;
using TrackSampleStart.Domain;
using Xunit;

namespace TrackSampleStart.Tests
{
    public class RepositoryTests : IClassFixture<SharedContainerFixture>
    {
        private SharedContainerFixture _container;
        private IGetTalkRepository _repository;
        private List<Talk> _allTalks;

        public RepositoryTests(SharedContainerFixture container)
        {
            _container = container;

            _repository = _container.SharedWindsorContainer.Resolve<IGetTalkRepository>();
        }

        public void Act()
        {
            _allTalks = _repository.GetAll();
        }

        [Fact]
        public void Talks_count_should_be_correct()
        {
            Act();
            _allTalks.Count.Should().Be(19);
        }
    }
}