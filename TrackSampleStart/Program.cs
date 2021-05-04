using System;
using System.Collections.Generic;
using Castle.Windsor;
using TrackSampleStart.Domain;
using TrackSampleStart.DomainServices;
using TrackSampleStart.Shared;

namespace TrackSampleStart
{
    
    class Program
    {

        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Install(new RepositoryInstaller());
            container.Install(new ServicesInstaller());


            var service = container.Resolve<IService>();

            var tracks = new List<Track>();
            try
            {
                tracks = service.GetAllTracks();
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }


            var time = new TimeSpan(9, 0, 0);
            var index = 1;

            // For demo purposes show data in tracks
            foreach (var track in tracks)
            {
                System.Console.WriteLine(track.Title);

                // Show all sessions from a track. In this demo a track only exists out of 2 sessions.
                // One in the morning the other one in the afternoon
                foreach (var session in track.Sessions)
                {
                    DateTime formatTime;
                    foreach (var talk in session.Talks)
                    {
                        formatTime = DateTime.Today.Add(time);
                        Console.WriteLine("{0:hh:mm tt} {1}", formatTime, talk.Title);
                        time = time.Add(talk.Duration);
                    }

                    if (session.DayPart == DayPart.Morning)
                    {
                        time = new TimeSpan(12, 0, 0);
                        formatTime = DateTime.Today.Add(time);
                        Console.WriteLine("{0:hh:mm tt} Lunch", formatTime);
                    }
                    else
                    {
                        // Networking Event can not start before 4pm
                        if (time.TotalHours < 16)
                            time = new TimeSpan(16, 0, 0);

                        formatTime = DateTime.Today.Add(time);
                        Console.WriteLine("{0:hh:mm tt} Networking Event", formatTime);
                    }
                    time = time.Add(new TimeSpan(1, 0, 0));
                }

                Console.WriteLine("");

                //Reset time to start day at 9:00am
                time = new TimeSpan(9, 0, 0);
            }
        }
    }
}
