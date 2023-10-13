using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ParkingMgmtService
    {
        private readonly DataAccessLayer.ParkingMgmtRepo _ParkingMgmtRepo;

        public ParkingMgmtService()
        {
            _ParkingMgmtRepo = new DataAccessLayer.ParkingMgmtRepo();
        }
        public DataTable GetMasterData(string MasterName)
        {
            return _ParkingMgmtRepo.GetMasterData(MasterName).Tables[0];
        }
        public DataTable CreateParkingSlotType(string SlotType)
        {
            return _ParkingMgmtRepo.CreateParkingSlotType(SlotType).Tables[0];
        }
        public DataTable CreateVehicleType(int SlotTypeId,string VehicleType)
        {
            return _ParkingMgmtRepo.CreateVehicleType(SlotTypeId, VehicleType).Tables[0];
        }
        public DataTable CreateParkingSlots(int SlotTypeId, int SlotSize)
        {
            return _ParkingMgmtRepo.CreateParkingSlots(SlotTypeId, SlotSize).Tables[0];
        }
    }
}
