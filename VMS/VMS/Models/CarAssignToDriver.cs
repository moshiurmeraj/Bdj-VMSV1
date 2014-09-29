using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VMS.Models
{
    public class CarAssignToDriver
    {
        public int CarAssignToDriverId { set; get; }



        public int CarId { set; get; }

        public virtual Car Cars { set; get; }

        public int DriverId { set; get; }
        public virtual Driver Drivers { set; get; }
        [Display(Name = "Car Assign From:")]
        public DateTime FromCarAssignDate { get; set; }

        [Display(Name = "Car Assign To:")]
        public DateTime ToCarAssignDate { get; set; }
    }
}