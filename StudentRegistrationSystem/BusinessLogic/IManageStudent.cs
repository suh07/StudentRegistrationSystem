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
        bool AddStudentResult(List<Result> result, int userId);
    }
}
