using System;
using System.Text.RegularExpressions;

namespace TrackSampleStart.Parsers
{
    public class Parser : IParser
    {
        public bool Success { get; set; }

        public  TimeSpan LightningParser(string text)
        {
            if (text.ToLower().EndsWith("lightning"))
            {
                Success = true;
                return new TimeSpan(0, 5, 0);
            }
            Success = false;
            return new TimeSpan(0, 0, 0);

        }
        public TimeSpan MinuteParser(string text)
        {
            var result = 0;
            var matches = Regex.Match(text, @"(\d+)", RegexOptions.IgnoreCase);
            if (matches.Success)
            {
                int.TryParse(matches.Captures[0].Value, out result);
            }

            Success = result > 0;

            return new TimeSpan(0, result, 0);
        }
    }
}