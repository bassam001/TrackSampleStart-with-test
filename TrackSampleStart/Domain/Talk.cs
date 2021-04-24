using System;
using System.Collections.Generic;
using System.Linq;

namespace TrackSampleStart.Domain
{
    public class Talk
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
    }

    public static class TalkExtensionTalk
    {
        public static int TotalMinutes(this List<Talk> talks) 
        {
            return talks.Sum(talk => (int)talk.Duration.TotalMinutes);
        }
    }
}