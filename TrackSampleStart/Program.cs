using System;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using TrackSampleStart.Domain;
using TrackSampleStart.DomainServices;
using TrackSampleStart.Shared;

namespace TrackSampleStart
{
    // You are planning a big programming conference and have received many proposals which have passed the initial screen process but you're having trouble 
    // fitting them into the time constraints of the day -- there are so many possibilities!
    // So you write a program to do it for you.

    // The conference has multiple tracks each of which has a morning and afternoon session.
    // Each session contains multiple talks.
    // Morning sessions begin at 9am and must finish by 12 noon, for lunch.
    // Afternoon sessions begin at 1pm and must finish in time for the networking event.
    // The networking event can start no earlier than 4:00 and no later than 5:00.
    // No talk title has numbers in it.
    // All talk lengths are either in minutes (not hours) or lightning (5 minutes).
    // Presenters will be very punctual; there needs to be no gap between sessions.

    // Note that depending on how you choose to complete this problem, your solution may give a different ordering or combination of talks into tracks.
    // This is acceptable; you don't need to exactly duplicate the sample output given here.

    // The application should be able to load a textfile with all the tracks at once.

    // Test input:

    // Writing Fast Tests Against Enterprise Rails 60min
    // Overdoing it in Python 45min
    // Lua for the Masses 30min
    // Ruby Errors from Mismatched Gem Versions 45min
    // Common Ruby Errors 45min
    // Communicating Over Distance 60min
    // Accounting-Driven Development 45min
    // Woah 30min
    // Sit Down and Write 30min
    // Pair Programming vs Noise 45min
    // Rails Magic 60min
    // Ruby on Rails: Why We Should Move On 60min
    // Clojure Ate Scala(on my project) 45min
    // Programming in the Boondocks of Seattle 30min
    // Ruby vs.Clojure for Back-End Development 30min
    // Ruby on Rails Legacy App Maintenance 60min
    // A World Without HackerNews 30min
    // User Interface CSS in Rails Apps 30min
    // Rails for Python Developers lightning


    //Test output: 

    //Track 1:

    // 09:00AM Writing Fast Tests Against Enterprise Rails 60min
    // 10:00AM Overdoing it in Python 45min
    // 10:45AM Lua for the Masses 30min
    // 11:15AM Ruby Errors from Mismatched Gem Versions 45min
    // 12:00PM Lunch
    // 01:00PM Ruby on Rails: Why We Should Move On 60min
    // 02:00PM Common Ruby Errors 45min
    // 02:45PM Pair Programming vs Noise 45min
    // 03:30PM Programming in the Boondocks of Seattle 30min
    // 04:00PM Ruby vs.Clojure for Back-End Development 30min
    // 04:30PM User Interface CSS in Rails Apps 30min
    // 05:00PM Networking Event

    //Track 2:

    // 09:00AM Communicating Over Distance 60min
    // 10:00AM Rails Magic 60min
    // 11:00AM Woah 30min
    // 11:30AM Sit Down and Write 30min
    // 12:00PM Lunch
    // 01:00PM Accounting-Driven Development 45min
    // 01:45PM Clojure Ate Scala (on my project) 45min
    // 02:30PM A World Without HackerNews 30min
    // 03:00PM Ruby on Rails Legacy App Maintenance 60min
    // 04:00PM Rails for Python Developers lightning
    // 05:00PM Networking Event

    class Program
    {
        static void Main(string[] args)
        {

            var container = new WindsorContainer();

            // Register the type with the container
            container.Register(Component.For<IService>().ImplementedBy<Service>());

            // Resolve an object (ask the container for an instance)
            // This is analagous to calling new() in a non-IoC application.

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
