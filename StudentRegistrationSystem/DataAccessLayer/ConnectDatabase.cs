using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.DataAccessLayer
{
    public class ConnectDatabase :IConnectDatabase
    {
        private SqlConnection conn = null;
        private void Open()
        {
            string connetionString = "Data Source=L-PW02X08Y;Initial Catalog=StudentRegistration;Integrated Security=True";
            conn = new SqlConnection(connetionString);
            conn.Open();

        }



        private void Close()
        {
            conn.Close();
        }



        public void NonQuery(SqlCommand command)
        {
            try
            {
                Open();
            }
            catch (Exception ex)
            {



            }
            finally
            {
                Close();
            }
        }
        public DataTable QueryConditions(string query, List<SqlParameter> parameters)
        {
            Open();
            DataTable data = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.CommandType = CommandType.Text;
                    if (parameters != null)
                    {
                        parameters.ForEach(parameter =>
                        {
                            command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                        });
                    }
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        sda.Fill(data);
                    }

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            Close();
            return data;
        }


        public DataTable GetDataWithConditions(string query, List<SqlParameter> parameters)
        {
            Open();
            DataTable data = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.CommandType = CommandType.Text;
                    if (parameters != null)
                    {
                        parameters.ForEach(parameter =>
                        {
                            command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                        });
                    }
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        sda.Fill(data);
                    }

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }

            Close();

            return data;
        }
        public bool InsertUpdateData(string query, List<SqlParameter> parameters)
        {
            var rowAffected = 0;

            Open();
            DataTable data = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.CommandType = CommandType.Text;
                    if (parameters != null)
                    {
                        parameters.ForEach(parameter =>
                        {
                            command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                        });
                    }
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        sda.Fill(data);
                    }

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            Close();
            var result = rowAffected > 0 ? true : false;
            return result;
        }
     
    }
}
