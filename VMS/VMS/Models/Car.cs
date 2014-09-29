using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VMS.Models
{
    public class Car
    {
        public int CarId { set; get; }
        public enum  CarType
        {
            Ac=1,
            NonAc=2
        }

        [Required]
        [Display(Name = "Select Car Type")]
        public CarType? TypeOfCar { get; set; }

        public enum CarCurrentStatus
        {
            InUse = 1,
            NotInUse = 2
        }


        [Display(Name = "Current Status of Car")]
        public CarCurrentStatus? CarStatus { set; get; }



       
        [Required]
        [Display(Name = "Car Name")]
        public string CarName { get; set; }


 

        [Required]
        [Display(Name = "Car Number")]
        public string CarNumber { set; get; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Purchasing Date")]
        public DateTime PurchasingDate { set; get; }

       
        [Display(Name = "Car Chassis No")]
        public string ChassisNo { set; get; }


        [Display(Name = " No of Seat")]
        public string SeatCapacity { set; get; }
      
    }
}