using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;

namespace StudentRegistrationSystem.DataAccessLayer
{
    public class ManageUserDAL : IManageUserDAL
    {
        private const string AddUserQuery = @"Insert into Student
        ([UserId],[FirstName],[LastName],[GuardianName],[NationalId],[DateOfBirth],  [StudentAddress],[PhoneNumber], [StudentStatus])
        values ( @UserId , @FirstName, @LastName,@GuardianName,@NationalId, @DateOfBirth, @StudentAddress,@PhoneNumber, @Status)";

        private const string GetUserQuery = @"Select [NationalID],[FirstName],[LastName], [PhoneNumber], [DateOfBirth], [GuardianName], [StudentAddress],[EmailAddress] from Student,Users;";
        private readonly IConnectDatabase ConnectDatabase;

        public ManageUserDAL(IConnectDatabase connectDatabase)
        {
            ConnectDatabase = connectDatabase;
        }
        public User GetUserByEmail(string email)
        {
            User user = null;
            string query = @"SELECT UserId, UserPassword FROM Users WHERE EmailAddress=@EmailAddress";
            List<SqlParameter> parameters=new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EmailAddress",email));
            DataTable result = ConnectDatabase.QueryConditions(query, parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row=result.Rows[0];
                user = new User();
                user.UserId = (int)row["UserId"];
                user.EmailAddress = email;
                user.UserPassword = row["UserPassword"].ToString();
            }
            return user;
        }
        public bool AddUser(User user)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            string Status = "Waiting";
            int UserId = 0;
            string query = @"INSERT INTO Users(RoleName, RoleId,EmailAddress, UserPassword)" + "VALUES(@RoleName,@RoleId,@EmailAddress, @UserPassword)";
            parameters.Add(new SqlParameter("@EmailAddress", user.EmailAddress));
            parameters.Add(new SqlParameter("@Password", user.UserPassword));
            ConnectDatabase.InsertData(query, parameters);
            query = "SELECT UserId FROM Users WHERE EmailAddress=@EmailAddress";
            DataTable result = ConnectDatabase.QueryConditions(query, parameters);
            UserId = (int)result.Rows[0]["UserId"];

            parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@NationalID", user.Student.NationalId));
            parameters.Add(new SqlParameter("@FirstName", user.Student.FirstName));
            parameters.Add(new SqlParameter("@LastName", user.Student.LastName));
            parameters.Add(new SqlParameter("@PhoneNumber", user.Student.PhoneNumber));
            parameters.Add(new SqlParameter("@DateOfBirth", user.Student.DateOfBirth));
            parameters.Add(new SqlParameter("@GuardianName", user.Student.GuardianName));
            parameters.Add(new SqlParameter("@StudentAddress", user.Student.StudentAddress));
            parameters.Add(new SqlParameter("@UserId", UserId));
            parameters.Add(new SqlParameter("@StudentStatus", Status));

            return ConnectDatabase.InsertData(AddUserQuery, parameters);
        }

        public bool CheckExistedUser(string emailAddress)
        {
            string query = @"SELECT EmailAddress from Users WHERE EmailAddress = @email";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@email", emailAddress));

            DataTable result = ConnectDatabase.QueryConditions(query, parameters);

            return result.Rows.Count > 0;
        }
        public List<User> GetAllUser(User user)
        {
            List<User> userList = null;
            DataTable dt = ConnectDatabase.GetUserDetails(GetUserQuery);

            if (dt.Rows.Count > 0)
            {
                  userList = new List<User>();
                foreach (DataRow row in dt.Rows)
                {
                    user.Student.FirstName = row["FirstName"].ToString();
                    user.Student.LastName = row["Surname"].ToString();
                    user.Student.NationalId = row["NationalId"].ToString();
                    user.Student.StudentAddress = row["StudentAddress"].ToString();
                    user.Student.PhoneNumber = row["PhoneNumber"].ToString();
                    user.Student.DateOfBirth = DateTime.Parse(row["DateOfBirth"].ToString());
                    user.Student.GuardianName = row["GuardianName"].ToString();
                    user.EmailAddress = row["EmailAddress"].ToString();

                    userList.Add(user);
                }
            }

            return userList;
        }

        public bool AddUserDB(User user)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.UserPassword);

            List<SqlParameter> parameters = new List<SqlParameter>();
           
            string RoleName = "Student";
            string query = @"INSERT INTO Users(RoleName, RoleId, EmailAddress, UserPassword) 
                             VALUES (@RoleName, @RoleId, @EmailAddress, @Password)";
            parameters.Add(new SqlParameter("@RoleId", Role.Student));
            parameters.Add(new SqlParameter("@RoleName", RoleName));
            parameters.Add(new SqlParameter("@EmailAddress", user.EmailAddress));
            parameters.Add(new SqlParameter("@Password", passwordHash));

            DataTable result = ConnectDatabase.QueryConditions(query, parameters);

            return result.Rows.Count > 0;
        }
    }
}