using System;
using System.Collections.Generic;
using System.Linq;
using TrackSampleStart.Infrastructure;

namespace TrackSampleStart.Parsers
{
    // todo Base class niet echt juist
    public class TalkParser 
    {
        public IEnumerable<IParser> Parsers { get; set; }

        public TalkParser(IEnumerable<IParser> parsers)
        {
            Utils.ThrowIfNull(() => parsers);
            Parsers = parsers;
        }


        public TimeSpan Time(string msg)
        {
            var parser = Parsers.SingleOrDefault(c => c.IsMatch(msg));
            if (parser != null)
            {
                return parser.Time(msg);
            }
            throw new Exception("Can't process line");
        }
    }
}