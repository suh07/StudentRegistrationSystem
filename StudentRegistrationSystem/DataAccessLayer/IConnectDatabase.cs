using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Collections;

namespace StudentRegistrationSystem.DataAccessLayer
{
    public interface IConnectDatabase
    {
        DataTable QueryConditions(string query, List<SqlParameter> parameters);
        bool InsertData(string query, List<SqlParameter> parameters);
    }
}