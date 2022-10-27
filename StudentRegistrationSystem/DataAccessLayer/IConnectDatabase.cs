using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.DataAccessLayer
{
    public interface IConnectDatabase
    {
        bool InsertUpdateData(string query, List<SqlParameter> parameters);

        DataTable GetDataWithConditions(string query, List<SqlParameter> parameters);

        void NonQuery(SqlCommand command);
        DataTable QueryConditions(string query, List<SqlParameter> parameters);

    }
}