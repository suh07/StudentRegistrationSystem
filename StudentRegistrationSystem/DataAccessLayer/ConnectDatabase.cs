using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Collections;
using System.Configuration;

namespace StudentRegistrationSystem.DataAccessLayer
{
    public class ConnectDatabase :IConnectDatabase
    {
        private SqlConnection connection = null;
        private void OpenConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        private void CloseConnection()
        {
            connection.Close();
        }
        public DataTable QueryConditions(string query, List<SqlParameter> parameters)
        {
            OpenConnection();
            DataTable data = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;

                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                    {
                        sqlData.Fill(data);
                    }
                }
            }
            catch (Exception Error)
            {
                throw Error;
            }
            CloseConnection();
            return data;
        }
        public bool InsertData(string query, List<SqlParameter> parameters)
        {
            OpenConnection();
            var rowAffected = 0;
           
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.CommandType = CommandType.Text;
                if (parameters != null)
                {
                    parameters.ForEach(parameter => {
                        command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                    });
                }
                rowAffected = command.ExecuteNonQuery();
            }
            CloseConnection();
            var result = rowAffected > 0 ? true : false;
            return result;
        }
    }
}
