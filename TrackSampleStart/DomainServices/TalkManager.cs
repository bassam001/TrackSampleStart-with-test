using System.Collections.Generic;
using TrackSampleStart.Domain;
using TrackSampleStart.Infrastructure;
using TrackSampleStart.Parsers;

namespace TrackSampleStart.DomainServices
{
    public class TalkManager
    {
        private readonly IParser _parser;

        public TalkManager(IParser parser)
        {
            Utils.ThrowIfNull(() => parser);

            _parser = parser;
        }

        //Update all talk entities with the duration time by using our talk title parser
        public void ParseTalkEntities(List<Talk> entities)
        {
            foreach (var item in entities)
            {
                var result = _parser.Time(item.Title);
                if (!_parser.Success) continue;

                item.Duration = result;
            }
        }
    }
}