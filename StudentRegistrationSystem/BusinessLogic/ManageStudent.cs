using System;
using System.Collections.Generic;
using StudentRegistrationSystem.DataAccessLayer;
using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.BusinessLogic
{

    public class ManageStudent : IManageStudent
    {
        private readonly IManageStudentDAL _manageStudentDAL;
        public ManageStudent(IManageStudentDAL manageStudentDAL)
        {
            _manageStudentDAL = manageStudentDAL;
        }
        public bool AddStudentResult(List<Result> resultList, int userId)
        {
            bool isResultAdded = false;
                isResultAdded = _manageStudentDAL.isResultAdded(resultList, userId);
            return isResultAdded;
        }

    }
}