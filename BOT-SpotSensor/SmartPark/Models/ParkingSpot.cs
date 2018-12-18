using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartPark.Models
{
    public class ParkingSpot
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string Timestamp { get; set; }
        public int BatteryStatus { get; set; }

    }
}