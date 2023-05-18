using EA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.IRepository
{
    public interface ILoginRepository
    {
        int CheckLogin(int enrollID);
        int Login(string emailId, string password);
        bool CheckEmailForPasswordChange(string emailId);
        bool UpdatePassword(EnrollmentViewModel enrollmentViewModel);
    }
}
