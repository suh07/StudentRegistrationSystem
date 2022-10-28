using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.DataAccessLayer
{
    public class ManageUserDAL : IManageUserDAL
    {
        private readonly IConnectDatabase ConnectDatabase;

        public ManageUserDAL(IConnectDatabase connectDatabase)
        {
            ConnectDatabase = connectDatabase;
        }

        public User GetUserByEmail(string email)
        {
            User user = null;
            string query = @"SELECT UserId, Password FROM Users WHERE EmailAddress=@EmailAddress";
            List<SqlParameter> parameters=new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EmailAddress",email));
            DataTable result = ConnectDatabase.QueryConditions(query, parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row=result.Rows[0];
                user= new User((int)row["UserId"]);
                user.EmailAddress = email;
                user.Password = row["Password"].ToString();
            }
            return user;
        }
    }
}