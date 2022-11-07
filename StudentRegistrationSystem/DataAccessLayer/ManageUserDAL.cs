using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Reflection;
using Unity.Policy;

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
            string getUserDetailsQuery = @"SELECT UserId, UserPassword, RoleId FROM Users WHERE EmailAddress=@EmailAddress";         
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EmailAddress", email));
            DataTable result = ConnectDatabase.QueryConditions(getUserDetailsQuery, parameters);
            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                user = new User();
                user.UserId = (int)row["UserId"];
                user.EmailAddress = email;
                user.UserPassword = row["UserPassword"].ToString();
                user.RoleId = row["RoleId"].ToString();
            }
            return user;
        }
        public bool CheckExistedUser(User user)
        {
            string ChexkExistingUserQuery = @"
                    SELECT* FROM Student s
                        INNER JOIN Users u ON s.UserId = u.UserId
                    WHERE s.NationalId = @NationalId OR s.PhoneNumber = @PhoneNumber OR u.EmailAddress = @EmailAddress";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EmailAddress", user.EmailAddress));
            parameters.Add(new SqlParameter("@PhoneNumber", user.Student.PhoneNumber));
            parameters.Add(new SqlParameter("@NationalId", user.Student.NationalId));
            DataTable result = ConnectDatabase.QueryConditions(ChexkExistingUserQuery, parameters);
            return result.Rows.Count > 0;
        }
        public bool AddUserDB(User user)
        {
            if (!InsertUser(user))
            {
                return false;
            }

            return InsertStudent(user.Student, user.UserId);
        }

        private bool InsertUser(User user)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.UserPassword);
            string inserIntoUserQuery = @"
                INSERT INTO Users(RoleName, RoleId, EmailAddress, UserPassword) 
                OUTPUT INSERTED.UserId
                VALUES (@RoleName, @RoleId, @EmailAddress, @Password)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@RoleName", "Student"));
            parameters.Add(new SqlParameter("@RoleId", Role.Student));
            parameters.Add(new SqlParameter("@EmailAddress", user.EmailAddress));
            parameters.Add(new SqlParameter("@Password", passwordHash));
            DataTable result = ConnectDatabase.QueryConditions(inserIntoUserQuery, parameters);
            if (result.Rows.Count > 0)
            {
                user.UserId = (int)result.Rows[0]["UserId"];

                return true;
            }

            return false;
        }
        private bool InsertStudent(Student student, int userId)
        {
            string insertIntoStudentQuery = @"
                INSERT INTO Student ([UserId],[FirstName],[LastName],[GuardianName],[NationalId],[DateOfBirth], [StudentAddress],[PhoneNumber], [StudentStatus])
                VALUES (@UserId, @FirstName, @LastName, @GuardianName, @NationalId, @DateOfBirth, @StudentAddress,@PhoneNumber, @StudentStatus)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserId", userId));
            parameters.Add(new SqlParameter("@FirstName", student.FirstName));
            parameters.Add(new SqlParameter("@LastName", student.LastName));
            parameters.Add(new SqlParameter("@GuardianName", student.GuardianName));
            parameters.Add(new SqlParameter("@NationalId", student.NationalId));
            parameters.Add(new SqlParameter("@DateOfBirth", student.DateOfBirth));
            parameters.Add(new SqlParameter("@StudentAddress", student.StudentAddress));
            parameters.Add(new SqlParameter("@PhoneNumber", student.PhoneNumber));
            parameters.Add(new SqlParameter("@StudentStatus", "Waiting"));
            DataTable result = ConnectDatabase.QueryConditions(insertIntoStudentQuery, parameters);
            return result.Rows.Count > 0;
        }
    }
}