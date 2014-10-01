using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VMS.Models
{
    public class Driver
    {
        public int DriverId { get; set; }
        public enum DriverCurrentStatus
        {
            InJob,
            NotInJob
        }

        [Required]
        [Display(Name = "Driver Name")]
        public string DriverName { set; get; }

        [Required]
        [Display(Name = "Contact Number")]
        public string ContactNo { set; get; }

        [Required]
        [Display(Name = "Liscence Number")]
        public string LiscenceNo { set; get; }

        [DataType(DataType.MultilineText)]
        public string Address { set; get; }

        [Required]
        public double Experience { set; get; }

        [DataType(DataType.Date)]
        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { set; get; }

        [Display(Name = "Current Status of Driver")]
        public DriverCurrentStatus DriverStatus { set; get; }
    }
}