using System.Collections.Generic;
using System.IO;
using TrackSampleStart.Domain;
using TrackSampleStart.Infrastructure;

namespace TrackSampleStart.Repository
{
    public class GetTalkRepository : IGetTalkRepository
    {
        private readonly FileInfo File;

        public GetTalkRepository(string file)
        {
            Utils.ThrowIfNull(() => file);

            var fileInfo = new FileInfo(file);
            if (!fileInfo.Exists)
                throw new FileNotFoundException("Could not find the file to process.");

            File = fileInfo;
        } 

        public List<Talk> GetAll()
        {
            var talks = new List<Talk>();

            // Start reading file, using is making sure the streamer is getting disposed since textreader is implementing IDisposable
            using (var sr = new StreamReader(File.FullName))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();

                    talks.Add(new Talk
                    {
                        Title = line
                    });
                }
            }
            return talks;
        }
    }
}