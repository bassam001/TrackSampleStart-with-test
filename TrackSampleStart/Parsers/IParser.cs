using System;

namespace TrackSampleStart.Parsers
{
    public interface IParser
    {
        bool Success { get; set; }
        TimeSpan Time(string text);
    }

    public abstract class Parser : IParser
    {
        public bool Success { get; set; }
        public abstract TimeSpan Time(string text);
    }
}