using System;
using System.Collections.Generic;
using System.Text;
using TrackSampleStart.Domain;

namespace TrackSampleStart.Repository
{
    public class ITestRepository 
    {
        public string GetFakeData()
        {
           return "Rails for Python Developers 15min";
        }
        public Talk GetFakeTalk()
        {
            Talk talk = new Talk();
            talk.Title = "Accounting-Driven Development";
            talk.Duration = new TimeSpan(00, 15, 00);
            return talk;
        }


    }
}
