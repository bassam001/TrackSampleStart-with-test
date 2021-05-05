using System;
using System.Text.RegularExpressions;

namespace TrackSampleStart.Parsers
{
    public class MinuteParser : Parser
    {
        public override TimeSpan Time(string text)
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