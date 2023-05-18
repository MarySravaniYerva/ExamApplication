using EA.Models;
using EA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.IBussinessLogic
{
    public interface IEnrollmentService
    {
        int Enrollment(EnrollmentViewModel enrollmentViewModel);
        int GetEnrollmentId(EnrollmentViewModel enrollmentViewModel);
        void SendOTP(string EmailId, OtpTypeEnum OTPType);
        bool VerifyOTP(string emailID, string OTP);
    }
}
