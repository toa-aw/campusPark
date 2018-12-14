using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartPark.Models
{
    public class ParkingSpot
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public Status Status { get; set; }
        public int BatteryStatus { get; set; }

    }
}