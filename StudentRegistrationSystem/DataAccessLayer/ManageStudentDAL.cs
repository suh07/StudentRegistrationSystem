using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace StudentRegistrationSystem.DataAccessLayer
{
   
    public class ManageStudentDAL : IManageStudentDAL
    {
        private const string resultQuery = @"INSERT INTO Result ([SubjectId],[SubjectGrade],[StudentId]) VALUES (@SubjectId,@SubjectGrade,@StudentId)";
        private readonly IConnectDatabase ConnectDatabase;
        private int userIDs;

        public ManageStudentDAL(IConnectDatabase connectDatabase)
        {
            ConnectDatabase = connectDatabase;
        }
        public bool isResultAdded(List<Result> listOfResults, int userId)
        {
            int ID = getStudentId(userId);
            bool isResultAdded = false;

            foreach (var result in listOfResults)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@SubjectId", result.SubjectId));
                parameters.Add(new SqlParameter("@SubjectGrade",result.SubjectGrade));
                parameters.Add(new SqlParameter("@StudentId",ID));
                isResultAdded = ConnectDatabase.InsertData(resultQuery, parameters);
            }
            return isResultAdded;
        }
        
        private int getStudentId(int userID)
        {
            string query = @"SELECT StudentId FROM Student WHERE UserId=@UserId";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserId",userID));
            DataTable result = ConnectDatabase.QueryConditions(query, parameters);
            
            if (result.Rows.Count > 0)
                {
                    DataRow row = result.Rows[0];
                     userIDs = (int)row["StudentId"];
                }
           
            return userIDs;
        }
        /*
        public User GetUserByEmail(string email)
        {
            
            string query = @"SELECT StudentId FROM Users WHERE UserId=@UserId";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EmailAddress", email));
            DataTable result = ConnectDatabase.QueryConditions(query, parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                user = new User();
                user.UserId = (int)row["UserId"];
                user.EmailAddress = email;
                user.UserPassword = row["UserPassword"].ToString();
            }
            return user;
        }
        */
    }
}
