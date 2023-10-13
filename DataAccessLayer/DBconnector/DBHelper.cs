using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer.DBconnector
{
    public class DBHelper
    {
        private readonly string connectionstring;
        public DBHelper()
        {
            connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        }

        #region "Connection"
        public SqlConnection ParkingMgmt_Connection()
        {

            

            SqlConnection m_conn = new SqlConnection(connectionstring);

            if ((m_conn.State == ConnectionState.Broken) || (m_conn.State == ConnectionState.Closed))
            {
                m_conn.Open();
            }


            return m_conn;

        }

        #endregion



        #region "Attach Parameters"

        private void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            foreach (SqlParameter param in commandParameters)
            {
                if (param.Value == null)
                {
                    param.Value = DBNull.Value;
                }
                else if (param.Value.ToString() == "1/1/1999 12:00:00 AM")
                {
                    param.Value = DBNull.Value;
                }
                else if (param.Value.ToString() == DateTime.MinValue.ToString())
                {
                    param.Value = DBNull.Value;
                }
                else if (param.Value.ToString() == "01/01/1999 00:00:00")
                {
                    param.Value = DBNull.Value;
                }
                command.Parameters.Add(param);
            }
        }
        #endregion

        #region "Assign Parameter Value"
        private void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
        {
            try
            {
                if ((commandParameters == null) || (parameterValues == null))
                {
                    return;
                }
                for (int i = 0, j = commandParameters.Length; i < j; i++)
                {
                    try
                    {
                        commandParameters[i].Value = parameterValues[i];
                    }
                    catch { }

                }
            }
            catch
            {
            }
        }

        #endregion
        #region "Command"

        private void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            command.Connection = connection;
            command.CommandText = commandText;
            command.Transaction = transaction;
            command.CommandType = commandType;
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }

        #endregion

        #region "Execute Dataset"
        public DataSet ExecuteDataset(SqlConnection connection, SqlTransaction t, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlCommand cmdExecute = new SqlCommand())
            {
                PrepareCommand(cmdExecute, connection, t, commandType, commandText, commandParameters);
                using (SqlDataAdapter daExecute = new SqlDataAdapter(cmdExecute))
                {
                    using (DataSet dstExecute = new DataSet())
                    {
                        cmdExecute.CommandTimeout = 0;
                        daExecute.Fill(dstExecute);
                        cmdExecute.Parameters.Clear();
                        return dstExecute;
                    }
                }
            }
        }
        #endregion

        #region "Execute Non Query"
        public int ExecuteNonQuery(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlCommand cmdExecute = new SqlCommand())
            {
                PrepareCommand(cmdExecute, connection, transaction, commandType, commandText, commandParameters);
                cmdExecute.CommandTimeout = 0;
                int returnVal = cmdExecute.ExecuteNonQuery();
                return returnVal;
            }
        }
        #endregion
    }
}
