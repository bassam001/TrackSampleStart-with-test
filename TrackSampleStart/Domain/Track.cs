using System;
using System.Collections.Generic;
using TrackSampleStart.Shared;

namespace TrackSampleStart.Domain
{
    public class Track
    {
        public string Title { get; set; }
        public List<Session> Sessions { get; set; }

        public Track()
        {
            Sessions = new List<Session>
            {
                new Session {
                    DayPart = DayPart.Morning,
                    TimeAllowed = new TimeSpan(3,0,0)
                },
                new Session
                {
                    DayPart = DayPart.Afternoon,
                    TimeAllowed = new TimeSpan(4,0,0)
                }
            };
        }
    }

    public static class TrackExtenstions
    {
        // Check for all sessions if there is still a available time slot
        public static Session GetAvailableSessionFromTrack(this Track track, Talk talk)
        {
            var sessions = track.Sessions;

            foreach (var session in sessions)
            {
                var totalmin = session.Talks.TotalMinutes() + talk.Duration.TotalMinutes;
                if (session.TimeAllowed.TotalMinutes >= totalmin)
                {
                    return session;
                }
            }

            return null;
        }
    }
}