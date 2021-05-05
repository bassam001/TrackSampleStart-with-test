using System;
using System.Collections.Generic;
using TrackSampleStart.Infrastructure;

namespace TrackSampleStart.Parsers
{
    // todo Base class niet echt juist
    public class TalkParser : Parser
    {
        public List<IParser> Parsers { get; set; }

        // Poor Man's Injection
        public TalkParser()
            : this(new List<IParser>
            {
                new MinuteParser(),
                new LightningParser()
            })
        { }

        public TalkParser(List<IParser> parsers)
        {
            Utils.ThrowIfNull(() => parsers);
            Parsers = parsers;
        }

        // Try to match a talk title with 1 of our parser expressions and return the result on success 
        public override TimeSpan Time(string msg)
        {
            Success = false;
            foreach (var parser in Parsers)
            {
                var result = parser.Time(msg);
                if (parser.Success)
                {
                    this.Success = true;
                    return result;
                }
            }

            throw new Exception("Can't process line");
        }
    }
}