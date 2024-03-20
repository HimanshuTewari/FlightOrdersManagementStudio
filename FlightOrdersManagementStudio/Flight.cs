using System;
using System.Collections.Generic;
using System.Linq;
namespace FlightOrdersManagementStudio
{
    public class Flight
    {
        public int FlightNumber { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }
        public int OrderCount { get; set; } = 0;
        public int MaxOrderCapacity { get; set; }
    }
}
