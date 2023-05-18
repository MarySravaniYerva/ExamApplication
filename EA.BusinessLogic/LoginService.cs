using EA.IBussinessLogic;
using EA.IRepository;
using EA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.BusinessLogic
{
    public class LoginService : ILoginservice
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public int CheckLogin(int enrollID)
        {
            var res = _loginRepository.CheckLogin(enrollID);
            return res;
        }
        public int Login(string emailId, string password)
        {
           var enrollId = _loginRepository.Login(emailId, password);
            return enrollId;

        }

        public bool CheckEmailForPasswordChange(string emailId)
        {
            var checkResult = _loginRepository.CheckEmailForPasswordChange(emailId);
            return checkResult;
        }
        public bool UpdatePassword(EnrollmentViewModel enrollmentViewModel)
        {
            var res = _loginRepository.UpdatePassword(enrollmentViewModel);
            return res;
        }
    }
}
