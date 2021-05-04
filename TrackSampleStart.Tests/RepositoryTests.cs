using System.Collections.Generic;
using Castle.Windsor;
using TrackSampleStart.Repository;
using FluentAssertions;
using TrackSampleStart.Domain;
using Xunit;

namespace TrackSampleStart.Tests
{
  public  class RepositoryTests
  {
      private IWindsorContainer _container;
      private IGetTalkRepository  _repository;
      private List<Talk> _allTalks;

      public RepositoryTests()
      {
          _container = new WindsorContainer();
          _container.Install(new RepositoryInstaller());
          _repository = _container.Resolve<IGetTalkRepository>();
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