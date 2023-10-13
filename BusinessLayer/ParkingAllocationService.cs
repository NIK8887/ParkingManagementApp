using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ParkingAllocationService
    {
        private readonly DataAccessLayer.ParkingAllocationRepo _parkingAllocationRepo;

        public ParkingAllocationService()
        {
            _parkingAllocationRepo = new DataAccessLayer.ParkingAllocationRepo();
        }

        public DataTable AllocateParking(string FullName,string Vehicleno,int VehicleTypeid)
        {
            return _parkingAllocationRepo.AllocateParking(FullName,Vehicleno,VehicleTypeid).Tables[0];
        }
        public DataTable DeAllocateParking(int SlotNo)
        {
            return _parkingAllocationRepo.DeAllocateParking(SlotNo).Tables[0];
        }
    }
}
