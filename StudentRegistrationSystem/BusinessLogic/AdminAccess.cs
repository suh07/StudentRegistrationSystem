using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentRegistrationSystem.DataAccessLayer;

namespace StudentRegistrationSystem.BusinessLogic
{
    public class AdminAccess : IAdminAccess
    {
        private readonly IManageStudentDAL _manageStudentDAL;
        public AdminAccess(IManageStudentDAL managerStudentDAL)
        {
            _manageStudentDAL = managerStudentDAL;
        }
        public object StudentStatus { get; private set; }
        public List<Student> GetTopFifteenStudent()
        {
            List<Student> students = _manageStudentDAL.GetStudentsWithResultInformation();
            List<Student> sortedListStudents = null;
            List<Student> sortedListStudentsWihPoints = null;
            if (students != null)
            {
                sortedListStudents = students.OrderByDescending(stud => stud.TotalPoints).ToList();
                sortedListStudentsWihPoints = assignStatusToAllStudent(sortedListStudents);
            }
            return sortedListStudentsWihPoints;
        }
        private List<Student> assignStatusToAllStudent(List<Student> students)
        {
            if (students != null)
            {
                if (students.Count > 15)
                {
                    for (int count = 0; count < 15; count++)
                    {
                        students[count] = setStatus(students[count], false);
                    }
                    for (int count = 15; count < students.Count; count++)
                    {
                        students[count] = setStatus(students[count], true);
                    }
                }
                else
                {
                    for (int count = 0; count < students.Count; count++)
                    {
                        students[count] = setStatus(students[count], false);
                    }
                }
            }         
            return students;
        }         
        private Student setStatus(Student studs, bool waiting)
        {
            if(studs != null)
            {
                if (waiting)
                {
                    if (studs.TotalPoints < 10)
                    {
                        studs.StudentStatus = Status.Rejected.ToString();
                    }
                    else
                    {
                        studs.StudentStatus=Status.Waiting.ToString();
                    }
                }
                else
                {
                    if (studs.TotalPoints < 10)
                    {
                        studs.StudentStatus = Status.Rejected.ToString();
                    }
                    else
                    {
                        studs.StudentStatus = Status.Approved.ToString();
                    }
                }

            }
            return studs;
        }
    }
}