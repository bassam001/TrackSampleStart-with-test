using System;

namespace TrackSampleStart.Parsers
{
    public interface IParser
    {
        bool Success { get; set; }
        TimeSpan Time(string text);
    }
}