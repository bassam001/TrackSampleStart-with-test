using System;
using System.Text.RegularExpressions;

namespace TrackSampleStart.Parsers
{
    public class MinuteParser : IParser
    {
        public bool IsMatch(string text)
        {
            var matches = Regex.Match(text, @"(\d+)", RegexOptions.IgnoreCase);
            return matches.Success;
        }

        public TimeSpan Time(string text)
        {
            var matches = Regex.Match(text, @"(\d+)", RegexOptions.IgnoreCase);
            var result = int.Parse(matches.Captures[0].Value);
            return new TimeSpan(0, result, 0);
            
        }
    }

}

