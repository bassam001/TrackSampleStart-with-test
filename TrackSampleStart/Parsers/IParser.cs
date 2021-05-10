using System;

namespace TrackSampleStart.Parsers
{
    public interface IParser
    {
        bool IsMatch(string text);
        TimeSpan Time(string text);
    }

}