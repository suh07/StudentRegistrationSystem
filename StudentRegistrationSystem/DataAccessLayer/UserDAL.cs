using StudentRegistrationSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.DataAccessLayer
{
    public class UserDAL : IUserDAL
    {
        private readonly IConnectDatabase _connectDatabase;

        public UserDAL(IConnectDatabase connectDatabase)
        {
            _connectDatabase = connectDatabase;
        }

        public bool CreateStudent(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            User user = null;
            string query = @"SELECT UserId, Password FROM Users WHERE EmailAddress=@EmailAddress";
            List<SqlParameter> parameters=new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EmailAddress",email));
            DataTable result = _connectDatabase.QueryConditions(query, parameters);

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