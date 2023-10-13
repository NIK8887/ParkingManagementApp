using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkingManagementApp.Models
{
    public class ParkingAllocationModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string VehicleNo { get; set; }
        [Required]
        public int VehicleTypeId { get; set; }

        public List<SelectListItem> VehicleTypeList { get; set; }

        public List<ParkingAllocationData> ParkingData { get; set; }

    }

    public class ParkingAllocationData
    {
        public int SlotNo { get; set; }
        public string Name { get; set; }
        
        public string VehicleNo { get; set; }
        
        public string VehicleType { get; set; }

       public string IsBooked { get; set; }

        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }


    }

}