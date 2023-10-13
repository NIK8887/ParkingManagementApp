using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkingManagementApp.Models
{
    

    public class CreateParkingSlotTypeMasterModel
    {
        [Required]
        public string SlotType { get; set; }
        public List<SelectListItem> SlotTypeList { get; set; }
    }

    public class CreateVehicleTypeMasterModel
    {
        [Required]
        [Display(Name ="Slot Type")]
        public int SlotTypeId { get; set; } = 0;
        [Required]
        [Display(Name = "Vehicle Type")]
        public string VehicleType { get; set; }

        public List<SelectListItem> SlotTypeList { get; set; }

        public List<SelectListItem> VehicleTypeList { get; set; }
    }

    public class CreateParkingSlotsMasterModel
    {
        [Required]
        [Display(Name = "Slot Type")]
        public int SlotTypeId { get; set; } = 0;

        [Required]
        public int SlotSize { get; set; }

        public List<SelectListItem> SlotTypeList { get; set; }

        public List<SlotDataModel> SlotData { get; set; }
    }
    public class SlotDataModel
    {
       
        public string SlotType { get; set; }
        public int SlotSize { get; set; }

        public int BookedSlot { get; set; }
    }






}

