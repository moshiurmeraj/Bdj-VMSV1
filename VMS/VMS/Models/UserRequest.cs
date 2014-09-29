using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VMS.Models
{
    public class UserRequest
    {

        public enum RequestStatus
        {
            Confirm = 1,
            Share = 2,
            Cancel = 3

        }
        public int UserRequestId { get; set; }

        [Display(Name = "Trip Start Time")]
        public DateTime JourneyStartTime { get; set; }

        [Display(Name = " Approximate Trip End Time")]
        public DateTime JourneyEndTime { get; set; }



        [DataType(DataType.MultilineText)]
        public string Purpose { get; set; }

        [Display(Name = "Comapny Name")]
        public string CompanyName { get; set; }

        public string Destination { get; set; }

        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        public virtual Designation Designation { get; set; }
    }
}