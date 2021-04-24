using System;

namespace TrackSampleStart.Parsers
{
    public class LightningParser : Parser
    {
        public override TimeSpan Time(string text)
        {
            if (text.ToLower().EndsWith("lightning"))
            {
                Success = true;
                return new TimeSpan(0, 5, 0);
            }
            Success = false; 
            return new TimeSpan(0, 0, 0);
        }
    }
}