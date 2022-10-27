using StudentRegistrationSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.BusinessLogic
{
    public interface IManageStudent
    {
        bool CreateStudent(User user);
       
    }
}
