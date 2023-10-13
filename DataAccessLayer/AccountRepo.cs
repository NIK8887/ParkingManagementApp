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
    public class AccountRepo
    {
        private readonly DataAccessLayer.DBconnector.DBHelper _dBHelper;

        public AccountRepo()
        {
            _dBHelper = new DBconnector.DBHelper();
        }

        public DataSet AuthenticateUser(string UserName, string Password)
        {
            using (SqlConnection con = _dBHelper.ParkingMgmt_Connection())
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter(SP_VariableConstants.Username, UserName);
                param[1] = new SqlParameter(SP_VariableConstants.Password, Password);               
                using (DataSet ds = _dBHelper.ExecuteDataset(con, null, CommandType.StoredProcedure, SP_Contstants.AuthenticateUser, param))
                {
                    return ds;
                }
            }

           
        }
    }
}
