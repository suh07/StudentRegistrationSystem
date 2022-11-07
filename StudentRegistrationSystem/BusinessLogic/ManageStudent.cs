using System;
using System.Collections.Generic;
using StudentRegistrationSystem.DataAccessLayer;
using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.BusinessLogic
{

    public class ManageStudent : IManageStudent
    {
        private readonly IManageStudentDAL _ManageStudentDAL;

        public ManageStudent(IManageStudentDAL ManageStudentDAL)
        {
            _ManageStudentDAL = ManageStudentDAL;
        }
        public bool AddStudentResult(List<Result> resultList, int userId)
        {
            bool isResultAdded = false;

                isResultAdded = _ManageStudentDAL.isResultAdded(resultList, userId);
      

            return isResultAdded;
        }

    }
}