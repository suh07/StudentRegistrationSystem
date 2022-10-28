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
        DataTable QueryConditions(string query, List<SqlParameter> parameters);
    }
}