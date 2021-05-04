using System;
using System.Collections.Generic;
using TrackSampleStart.Domain;

namespace TrackSampleStart.DomainServices
{
    public interface ITrackManager
    {
        void AddTalk(Talk talk);
        void AddTalks(IEnumerable<Talk> talk);
        List<Track> GetTracks();
        void ClearTracks();
    }

    public class TrackManager : ITrackManager
    {
        private readonly List<Track> _tracks = new List<Track>();
        private int _trackId;


        // private ctor so no-one can create an instance
        private TrackManager() { }


        // static field to hold the singleton
        // initialization is thread-safe because it is handled by the static ctor
        private static readonly TrackManager _instance = new TrackManager();

        // public static singleton instance
        public static TrackManager Instance
        {
            get { return _instance; }
        }

        public void AddTalks(IEnumerable<Talk> talks)
        {
            foreach (var talk in talks)
            {
                AddTalk(talk);
            }
        }

        public void AddTalk(Talk talk)
        {
            var session = GetAvailableSession(talk);
            session.Talks.Add(talk);
        }
        
        // todo niet echt pure code (ruben boos!)
        private Session GetAvailableSession(Talk talk)
        {
            Session availableSession = null;

            // Look for an available session in our tracks
            foreach (var track in _tracks)
            {
                availableSession = track.GetAvailableSessionFromTrack(talk);
            }

            //When no session found, create new track
            if (availableSession == null)
            {
                var createdTrack = CreateNewTrack();

                availableSession = createdTrack.GetAvailableSessionFromTrack(talk);
            }

            //When this null there is no session available in the track entity
            if (availableSession == null)
                throw new Exception("Track entity does not contain any free session slots");

            return availableSession;
        }

        public List<Track> GetTracks()
        {
            return _tracks;
        }

        public void ClearTracks()
        {
            _tracks.Clear();
        }
        private Track CreateNewTrack()
        {
            _trackId += 1;
            var newTrack = new Track()
            {
                Title = $"Track {_trackId}"
            };
            _tracks.Add(newTrack);
            return newTrack;
        }
    }
}