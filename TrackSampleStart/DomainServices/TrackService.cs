using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TrackSampleStart.Domain;
using TrackSampleStart.Parsers;
using TrackSampleStart.Repository;

namespace TrackSampleStart.DomainServices
{
    public interface ITrackService
    {
        List<Track> GetAllTracks();
    }

    public class TrackService : ITrackService
    {
        private readonly ITrackManager _manager;
        private readonly IGetTalkRepository _repository;

        private static readonly string File = Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName,
            "talks.txt");

        private TalkManager _talkManager;

        public TrackService() :
             this (new GetTalkRepository(File), 
                 new TalkManager(new TalkParser()), 
                 TrackManager.Instance )
        {
        }

        public TrackService(IGetTalkRepository repository,
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