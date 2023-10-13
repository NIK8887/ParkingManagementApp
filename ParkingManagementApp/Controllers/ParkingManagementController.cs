using ParkingManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using System.Data;

namespace ParkingManagementApp.Controllers
{
    [Authorize]
    public class ParkingManagementController : Controller
    {

        ParkingMgmtService _ParkingMgmtService = new ParkingMgmtService();

        public ActionResult Index()
        {
            return View("ParkingManagement");
        }

        public ActionResult ParkingSlotType()
        {
            DataTable responsedt2 = _ParkingMgmtService.GetMasterData("SlotType");
            CreateParkingSlotTypeMasterModel createParkingSlotTypeMasterModel = new CreateParkingSlotTypeMasterModel();
            createParkingSlotTypeMasterModel.SlotTypeList = ConvertDataTableToDDOptionList(responsedt2);

            return View("CreateParkingSlotType", createParkingSlotTypeMasterModel);
        }

        public ActionResult ParkingSlots()
        {
            
            DataTable responsedt1 = _ParkingMgmtService.GetMasterData("SlotType");
            DataTable responsedt2 = _ParkingMgmtService.GetMasterData("ParkingSlotData");
            CreateParkingSlotsMasterModel createParkingSlotsMasterModel1 = new CreateParkingSlotsMasterModel();
            createParkingSlotsMasterModel1.SlotTypeList = ConvertDataTableToDDOptionList(responsedt1);
            createParkingSlotsMasterModel1.SlotData = ConvertDataTableToParkingData(responsedt2);


            return View("CreateParkingSlots", createParkingSlotsMasterModel1);
            
        }


        public ActionResult VehicleType()
        {

            DataTable responsedt = _ParkingMgmtService.GetMasterData("SlotType");
            DataTable responsedt2 = _ParkingMgmtService.GetMasterData("VehicleType");
            CreateVehicleTypeMasterModel createVehicleTypeMasterModel = new CreateVehicleTypeMasterModel();
            createVehicleTypeMasterModel.SlotTypeList = ConvertDataTableToDDOptionList(responsedt);
            createVehicleTypeMasterModel.VehicleTypeList = ConvertDataTableToDDOptionList(responsedt2);
            return View("CreateVehicleType", createVehicleTypeMasterModel);
        }

        [HttpPost]
        public ActionResult CreateParkingSlotType(CreateParkingSlotTypeMasterModel createParkingSlotTypeMasterModel)
        {
            if (ModelState.IsValid)
            {
                DataTable responsedt = _ParkingMgmtService.CreateParkingSlotType(createParkingSlotTypeMasterModel.SlotType);                
                ViewBag.Message = responsedt.Rows[0]["Message"].ToString();                                
            }
            DataTable responsedt2 = _ParkingMgmtService.GetMasterData("SlotType");
            CreateParkingSlotTypeMasterModel createParkingSlotTypeMasterModel2 = new CreateParkingSlotTypeMasterModel();
            createParkingSlotTypeMasterModel2.SlotTypeList = ConvertDataTableToDDOptionList(responsedt2);
            return View("CreateParkingSlotType", createParkingSlotTypeMasterModel2);
            
        }
        [HttpPost]
        public ActionResult CreateVehicleType(CreateVehicleTypeMasterModel createVehicleTypeMasterModel)
        {
            if (ModelState.IsValid)
            {
                DataTable responsedt = _ParkingMgmtService.CreateVehicleType(createVehicleTypeMasterModel.SlotTypeId, createVehicleTypeMasterModel.VehicleType);

                ViewBag.Message = responsedt.Rows[0]["Message"].ToString();
            }
            DataTable responsedt1 = _ParkingMgmtService.GetMasterData("SlotType");
            DataTable responsedt2 = _ParkingMgmtService.GetMasterData("VehicleType");
            CreateVehicleTypeMasterModel createVehicleTypeMasterModel2 = new CreateVehicleTypeMasterModel();
            createVehicleTypeMasterModel2.SlotTypeList = ConvertDataTableToDDOptionList(responsedt1);
            createVehicleTypeMasterModel2.VehicleTypeList = ConvertDataTableToDDOptionList(responsedt2);
            return View("CreateVehicleType", createVehicleTypeMasterModel2);

        }
        [HttpPost]
        public ActionResult CreateParkingSlots(CreateParkingSlotsMasterModel createParkingSlotsMasterModel)
        {
            if (ModelState.IsValid)
            {

                DataTable responsedt = _ParkingMgmtService.CreateParkingSlots(createParkingSlotsMasterModel.SlotTypeId, createParkingSlotsMasterModel.SlotSize);

                ViewBag.Message = responsedt.Rows[0]["Message"].ToString();


                


            }

            DataTable responsedt1 = _ParkingMgmtService.GetMasterData("SlotType");
            DataTable responsedt2 = _ParkingMgmtService.GetMasterData("ParkingSlotData");
            CreateParkingSlotsMasterModel createParkingSlotsMasterModel1 = new CreateParkingSlotsMasterModel();
            createParkingSlotsMasterModel1.SlotTypeList = ConvertDataTableToDDOptionList(responsedt1);
            createParkingSlotsMasterModel1.SlotData = ConvertDataTableToParkingData(responsedt2);


            return View("CreateParkingSlots", createParkingSlotsMasterModel1);

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

        public List<SlotDataModel> ConvertDataTableToParkingData(DataTable dt)
        {
            List<SlotDataModel> items = new List<SlotDataModel>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    items.Add(new SlotDataModel
                    {                        
                        SlotType = Convert.ToString(dt.Rows[i]["SlotType"]),
                        SlotSize = Convert.ToInt32(dt.Rows[i]["SizeOfSlot"]),
                        BookedSlot = Convert.ToInt32(dt.Rows[i]["CountOfbookedslot"])
                    });


                }
            }
            return items;
        }
    }
}