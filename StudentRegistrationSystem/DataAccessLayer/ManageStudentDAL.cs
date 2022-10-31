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
        private const string resultQuery = @"INSERT INTO Result ([SubjectId],[Grade],[StudentId]) VALUES (@SubjectId,@Grade,@StudentId)";
        private readonly IConnectDatabase ConnectDatabase;

        public ManageStudentDAL(IConnectDatabase connectDatabase)
        {
            ConnectDatabase = connectDatabase;
        }
        public bool isResultAdded(List<Result> listOfResults, int userId)
        {
            bool isResultAdded = false;

            foreach (var result in listOfResults)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@SubjectId", result.SubjectId));
                parameters.Add(new SqlParameter("@Grade",result.Grade));
                parameters.Add(new SqlParameter("@StudentId",userId));
                isResultAdded = ConnectDatabase.InsertData(resultQuery, parameters);
            }
            return isResultAdded;
        }
    }
}
