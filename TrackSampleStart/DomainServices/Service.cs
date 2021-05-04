using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TrackSampleStart.Domain;
using TrackSampleStart.Repository;

namespace TrackSampleStart.DomainServices
{
    public interface IService
    {
        List<Track> GetAllTracks();
    }

    public class Service : IService
    {
        private readonly ITrackManager _manager;
        private readonly IGetTalkRepository _repository;
        private TalkManager _talkManager;

        private static readonly string File = Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName,
            "talks.txt");
        
        public Service(IGetTalkRepository repository,
                            TalkManager talkManager,
                            ITrackManager manager)
        {
            _talkManager = talkManager;
            _repository = repository;
            _manager = manager;
        }


        public List<Track> GetAllTracks()
        {
            var talks = _repository.GetAll();
            _talkManager.ParseTalkEntities(talks);

            _manager.AddTalks(talks);

            return _manager.GetTracks();
        }
    }
}