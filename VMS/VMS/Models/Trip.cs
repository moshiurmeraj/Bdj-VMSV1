using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VMS.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        public string CarAssignedPerson { get; set; }
        public string CarAssignedPersonDesignation { get; set; }
        public DateTime TripStartDateTime { get; set; }
        public DateTime TripEndDateTime { get; set; }
        public string Destination { get; set; }
        
    }
}