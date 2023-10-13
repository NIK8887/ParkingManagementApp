using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer.DBconnector;

namespace DataAccessLayer
{
    public class ParkingAllocationRepo
    {
        private readonly DataAccessLayer.DBconnector.DBHelper _dBHelper;

        public ParkingAllocationRepo()
        {
            _dBHelper = new DBconnector.DBHelper();
        }

        public DataSet AllocateParking(string FullName, string Vehicleno, int VehicleTypeid)
        {
            using (SqlConnection con = _dBHelper.ParkingMgmt_Connection())
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter(SP_VariableConstants.FullName, FullName);
                param[1] = new SqlParameter(SP_VariableConstants.VehicleNo, Vehicleno);
                param[2] = new SqlParameter(SP_VariableConstants.VehicleTypeId, VehicleTypeid);
                using (DataSet ds = _dBHelper.ExecuteDataset(con, null, CommandType.StoredProcedure, SP_Contstants.AllocateParking, param))
                {
                    return ds;
                }
            }


        }
        public DataSet DeAllocateParking(int SlotNo)
        {
            using (SqlConnection con = _dBHelper.ParkingMgmt_Connection())
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter(SP_VariableConstants.SlotNo, SlotNo);
                using (DataSet ds = _dBHelper.ExecuteDataset(con, null, CommandType.StoredProcedure, SP_Contstants.DeAllocateParking, param))
                {
                    return ds;
                }
            }


        }
    }
}
