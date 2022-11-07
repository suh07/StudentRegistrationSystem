using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.DataAccessLayer
{
    public interface IManageStudentDAL
    {
        bool isResultAdded(List<Result> listOfResults, int userId);
        List<Student>GetStudentsWithResultInformation();
    }
}
