using DataAccessLayer.DBconnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ParkingMgmtRepo
    {
        private readonly DataAccessLayer.DBconnector.DBHelper _dBHelper;

        public ParkingMgmtRepo()
        {
            _dBHelper = new DBconnector.DBHelper();
        }

        public DataSet GetMasterData(string MasterName)
        {
            using (SqlConnection con = _dBHelper.ParkingMgmt_Connection())
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter(SP_VariableConstants.MasterName, MasterName);
                using (DataSet ds = _dBHelper.ExecuteDataset(con, null, CommandType.StoredProcedure, SP_Contstants.GetMasterData, param))
                {
                    return ds;
                }
            }


        }

        public DataSet CreateParkingSlotType(string SlotType)
        {
            using (SqlConnection con = _dBHelper.ParkingMgmt_Connection())
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter(SP_VariableConstants.SlotType, SlotType);                
                using (DataSet ds = _dBHelper.ExecuteDataset(con, null, CommandType.StoredProcedure, SP_Contstants.InsertParkingSlotType, param))
                {
                    return ds;
                }
            }


        }
        public DataSet CreateVehicleType(int SlotTypeId,string VehicleType)
        {
            using (SqlConnection con = _dBHelper.ParkingMgmt_Connection())
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter(SP_VariableConstants.SlotTypeId, SlotTypeId);
                param[1] = new SqlParameter(SP_VariableConstants.VehicleType, VehicleType);
                using (DataSet ds = _dBHelper.ExecuteDataset(con, null, CommandType.StoredProcedure, SP_Contstants.InsertVehicleType, param))
                {
                    return ds;
                }
            }


        }
        public DataSet CreateParkingSlots(int SlotTypeId,int SlotSize)
        {
            using (SqlConnection con = _dBHelper.ParkingMgmt_Connection())
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter(SP_VariableConstants.SlotTypeId, SlotTypeId);
                param[1] = new SqlParameter(SP_VariableConstants.SlotSize, SlotSize);
                using (DataSet ds = _dBHelper.ExecuteDataset(con, null, CommandType.StoredProcedure, SP_Contstants.CreateParkingSlots, param))
                {
                    return ds;
                }
            }


        }
    }
}
