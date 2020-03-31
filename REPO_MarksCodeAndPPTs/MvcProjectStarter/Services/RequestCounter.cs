using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProjectStarter.Services
{
    public class RequestCounter : IRequestCounter
    {
        public int TotalRequestCount { get; private set; }

        public void IncrementRequestCount()
        {
            TotalRequestCount++;
        }
    }
}
