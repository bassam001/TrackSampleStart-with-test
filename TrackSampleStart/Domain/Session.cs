using System;
using System.Collections.Generic;
using TrackSampleStart.Shared;

namespace TrackSampleStart.Domain
{
    public class Session
    {
        public DayPart DayPart { get; set; }
        public TimeSpan TimeAllowed { get; set; }
        public List<Talk> Talks { get; set; }
        public Session()
        {
            Talks = new List<Talk>();
        }
    }
}