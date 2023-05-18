using EA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.IBussinessLogic
{
    public interface ILoginservice
    {
        int CheckLogin(int enrollID);
        int Login(string emailId, string password);
        bool CheckEmailForPasswordChange(string emailId);
        bool UpdatePassword(EnrollmentViewModel enrollmentViewModel);
    }
}
