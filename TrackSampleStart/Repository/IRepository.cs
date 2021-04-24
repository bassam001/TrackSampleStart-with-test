using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace TrackSampleStart.Repository
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
    }
}