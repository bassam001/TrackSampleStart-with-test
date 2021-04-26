using System;

namespace TrackSampleStart.Parsers
{
    public abstract class Parser : IParser
    {
        public bool Success { get; set; }
        public abstract TimeSpan Time(string text);
    }
}