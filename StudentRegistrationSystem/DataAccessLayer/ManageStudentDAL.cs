using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Collections;

namespace StudentRegistrationSystem.DataAccessLayer
{
    public class ManageStudentDAL : IManageStudentDAL
    {
        private const string InserResultQuery = @"INSERT INTO Result ([SubjectId],[SubjectGrade],[StudentId],[GradeScore]) VALUES (@SubjectId,@SubjectGrade,@StudentId,@GradeScore)";
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
                parameters.Add(new SqlParameter("@GradeScore", result.GradeScore));
                isResultAdded = ConnectDatabase.InsertData(InserResultQuery, parameters);
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
        public List<Student> GetStudentsWithResultInformation()
        {
            List<Student> students = new List<Student>();
            string getStudentResultQuery = @"SELECT Student.*, Score
                                            FROM Student
                                                INNER JOIN(SELECT Student.StudentId, SUM(GradeScore) AS [Score]
                                                           FROM Student
                                                                INNER JOIN Result ON Student.StudentId = Result.StudentId
                                                GROUP BY Student.StudentId) StudentScores ON StudentScores.StudentId = Student.StudentId;";
            DataTable result = ConnectDatabase.QueryConditions(getStudentResultQuery, null);
            if (result.Rows.Count > 0)
            {
                Student student = null;
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    student=new Student();
                    DataRow row = result.Rows[i];
                    int studentId = (int)row["StudentId"];

                    student.StudentId = studentId;
                    student.FirstName = row["FirstName"].ToString();
                    student.LastName = row["LastName"].ToString();
                    student.TotalPoints = Convert.ToInt32(row["Score"]);
                    students.Add(student);                   
                }
            }
            return students;
        }
    }
}
