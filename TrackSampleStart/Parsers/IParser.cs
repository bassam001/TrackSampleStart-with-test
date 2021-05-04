using System;

namespace TrackSampleStart.Parsers
{
    public interface IParser
    {
        bool Success { get; set; }
        TimeSpan MinuteParser(string text);
        TimeSpan LightningParser(string text);
    }
}