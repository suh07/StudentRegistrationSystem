using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.BusinessLogic
{
    public interface IManageStudent
    {
        string GetEnrollmentStatus();
        string GetStudentResult();
        bool AddStudentResult(List<Result> result, int userId);
    }
}
