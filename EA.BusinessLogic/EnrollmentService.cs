using EA.IBussinessLogic;
using EA.IRepository;
using EA.Models;
using EA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.BusinessLogic
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public int Enrollment(EnrollmentViewModel enrollmentViewModel) 
        {
            try
            {
            var loginStatus = _enrollmentRepository.Enrollment(enrollmentViewModel);
                return loginStatus;

            }
            catch (Exception)
            {
                throw ;
            }
        }
        public int GetEnrollmentId(EnrollmentViewModel enrollmentViewModel)
        {
            var enrollId = _enrollmentRepository.GetEnrollmentId(enrollmentViewModel);
            return enrollId;
        }

        public void SendOTP(string EmailId, OtpTypeEnum OTPType)
        {
            try
            {
                _enrollmentRepository.AddOTP(EmailId, OTPType);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool VerifyOTP(string emailID, string OTP)
        {
            bool isOtpVerified;
            try
            {
                isOtpVerified = _enrollmentRepository.VerifyOTP(emailID, OTP);
            }
            catch (Exception)
            {
                throw;
            }
            return isOtpVerified;
        }


    }
}
