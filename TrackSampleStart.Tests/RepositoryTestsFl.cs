using TrackSampleStart.Repository;
using FluentAssertions;
using Xunit;

namespace TrackSampleStart.Tests
{
  public  class RepositoryTestsFl
  {
     IGetTalkRepository  _repository;
    public RepositoryTestsFl()
      {
          _repository = new GetTalkRepository(new System.IO.FileInfo("Data/talks.txt").FullName);
      }

      [Fact]
      public void Talks_count_should_be_correct()
      {
          var talks = _repository.GetAll();
          talks.Count.Should().Be(3);
      }
    }
}