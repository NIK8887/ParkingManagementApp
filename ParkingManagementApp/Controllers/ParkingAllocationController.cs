using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkingManagementApp.Models;
using System.Data;
using BusinessLayer;

namespace ParkingManagementApp.Controllers
{
    [Authorize]
    public class ParkingAllocationController : Controller
    {
        // GET: Admin

        ParkingAllocationService ParkingAllocationService = new ParkingAllocationService();
        ParkingMgmtService _ParkingMgmtService = new ParkingMgmtService();

        public ActionResult Index()
        {
            DataTable responsedt2 = _ParkingMgmtService.GetMasterData("VehicleType");
            DataTable responsedt3 = _ParkingMgmtService.GetMasterData("ParkingData");
            ParkingAllocationModel parkingAllocationModel1 = new ParkingAllocationModel();
            parkingAllocationModel1.VehicleTypeList = ConvertDataTableToDDOptionList(responsedt2);
            parkingAllocationModel1.ParkingData = ConvertDataTableToParkingData(responsedt3);
            return View("AllocateParking", parkingAllocationModel1);

        }


        [HttpPost]
        public ActionResult AllocateParking(ParkingAllocationModel parkingAllocationModel)
        {
            if (ModelState.IsValid)
            {
                DataTable responsedt = ParkingAllocationService.AllocateParking(parkingAllocationModel.Name, parkingAllocationModel.VehicleNo, parkingAllocationModel.VehicleTypeId);

                ViewBag.Message = responsedt.Rows[0]["Message"].ToString();
            }
            DataTable responsedt2 = _ParkingMgmtService.GetMasterData("VehicleType");
            DataTable responsedt3 = _ParkingMgmtService.GetMasterData("ParkingData");
            ParkingAllocationModel parkingAllocationModel1 = new ParkingAllocationModel();
            parkingAllocationModel1.VehicleTypeList = ConvertDataTableToDDOptionList(responsedt2);
            parkingAllocationModel1.ParkingData = ConvertDataTableToParkingData(responsedt3);
            return View("AllocateParking", parkingAllocationModel1);

        }
        
        public ActionResult DeAllocateParking(int SlotNo)
        {
            if (SlotNo != 0)
            {
                DataTable responsedt = ParkingAllocationService.DeAllocateParking(SlotNo);

                ViewBag.Message = responsedt.Rows[0]["Message"].ToString();
            }

            DataTable responsedt2 = _ParkingMgmtService.GetMasterData("VehicleType");
            DataTable responsedt3 = _ParkingMgmtService.GetMasterData("ParkingData");
            ParkingAllocationModel parkingAllocationModel1 = new ParkingAllocationModel();
            parkingAllocationModel1.VehicleTypeList = ConvertDataTableToDDOptionList(responsedt2);
            parkingAllocationModel1.ParkingData = ConvertDataTableToParkingData(responsedt3);
            return View("AllocateParking", parkingAllocationModel1);

        }

        public List<SelectListItem> ConvertDataTableToDDOptionList(DataTable dt)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    items.Add(new SelectListItem
                    {
                        Text = Convert.ToString(dt.Rows[i]["Name"]),
                        Value = Convert.ToString(dt.Rows[i]["Id"])
                    });


                }
            }
            return items;
        }

        public List<ParkingAllocationData> ConvertDataTableToParkingData(DataTable dt)
        {
            List<ParkingAllocationData> items = new List<ParkingAllocationData>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ParkingAllocationData parkingAllocationData = new ParkingAllocationData();
                    parkingAllocationData.SlotNo = Convert.ToInt16(dt.Rows[i]["SlotNo"]);
                    parkingAllocationData.Name = Convert.ToString(dt.Rows[i]["UserName"]);
                    parkingAllocationData.VehicleNo = Convert.ToString(dt.Rows[i]["VehicleNo"]);
                    parkingAllocationData.VehicleType = Convert.ToString(dt.Rows[i]["VehicleType"]);
                    parkingAllocationData.CheckInTime = Convert.ToString(dt.Rows[i]["CheckInDateTime"]);
                    parkingAllocationData.CheckOutTime = Convert.ToString(dt.Rows[i]["CheckOutDateTime"]);
                    parkingAllocationData.IsBooked = Convert.ToInt16(dt.Rows[i]["IsBooked"]) == 1 ? "Yes" : "No";
                    items.Add(parkingAllocationData);

                }
            }
            return items;
        }
    }
}