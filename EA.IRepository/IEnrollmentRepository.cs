using EA.Models;
using EA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.IRepository
{
    public interface IEnrollmentRepository
    {
        int Enrollment(EnrollmentViewModel enrollmentViewModel);
        int GetEnrollmentId(EnrollmentViewModel enrollmentViewModel);
        string AddOTP(string EmailId, OtpTypeEnum OTPType);
        bool VerifyOTP(string emailID, string OTP);
        string GenerateOtp();
    }
}
