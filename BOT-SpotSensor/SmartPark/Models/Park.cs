using SmartPark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartPark.Models
{
    public class Park
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int NumberOfSpots { get; set; }
        public string OperatingHours { get; set; }
        public int NumberOfSpecialSpots { get; set; }
    }
}