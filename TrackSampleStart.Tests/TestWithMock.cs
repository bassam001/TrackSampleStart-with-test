using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Moq;
using TrackSampleStart.DomainServices;
using TrackSampleStart.Repository;
using Xunit;

namespace TrackSampleStart.Tests
{
   public class TestWithMock
    {
        private Mock<IGetTalkRepository> _getTalkRepository;

        
      
        [Fact]
        public void Talks_count_should_be_correct()
        {
            _getTalkRepository = new Mock<IGetTalkRepository>();
            _getTalkRepository.Setup(re => new GetTalkRepository(new System.IO.FileInfo("Data/talks.txt").FullName));
            var talks = _getTalkRepository.Object.GetAll();
            talks.Count.Should().Be(3);
        }

    }
}
