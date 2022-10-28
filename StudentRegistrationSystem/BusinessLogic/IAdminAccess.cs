using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.BusinessLogic
{
    internal interface IAdminAccess
    {
        string GetTopFifteenStudent();
    }
}
