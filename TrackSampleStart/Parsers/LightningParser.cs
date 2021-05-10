using System;

namespace TrackSampleStart.Parsers
{ 
    public class LightningParser : IParser
    {
       
        public bool IsMatch(string text)
        {
            return text.ToLower().EndsWith("lightning");
        }

        public TimeSpan Time(string text)
        {
            return new TimeSpan(0, 5, 0);
        }
    }
}
