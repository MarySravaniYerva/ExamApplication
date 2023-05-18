using EA.Database;
using EA.IRepository;
using EA.Models;
using EA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ExamApplicationDbContext _dbContext;
        public EnrollmentRepository(ExamApplicationDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        public int Enrollment(EnrollmentViewModel enrollmentViewModel)
        {
            try
            {
                EnrollmentModel enrollment = new EnrollmentModel();
                if (enrollmentViewModel != null) 
                {
                    enrollment.FirstName = enrollmentViewModel.FirstName;
                    enrollment.LastName = enrollmentViewModel.LastName;
                    enrollment.EmailId = enrollmentViewModel.EmailId;
                    enrollment.PhoneNumber = enrollmentViewModel.PhoneNumber;
                    enrollment.DateOfBirth = enrollmentViewModel.DateOfBirth;
                    enrollment.AadharNumber = enrollmentViewModel.AadharNumber;
                    string PasswordSalt = Utilities.SaltHash.Createsalt(20);
                    string PasswordHash = Utilities.SaltHash.CreateHash(enrollmentViewModel.Password, PasswordSalt);
                    enrollment.PasswordHash = PasswordHash;
                    enrollment.PasswordSalt = PasswordSalt;
                    _dbContext.Enrollments.Add(enrollment);
                    _dbContext.SaveChanges();
                    return 1;
                }
                return 0;
            }
           
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public int GetEnrollmentId(EnrollmentViewModel enrollmentViewModel)
        {
            if(enrollmentViewModel!= null)
            {
                var enrollDetails = _dbContext.Enrollments.Where(x=>x.EmailId == enrollmentViewModel.EmailId).FirstOrDefault();
                int enrollId = enrollDetails.EnrollId;

                return enrollId;

            }
            return 0;
        }


        //private string GenerateRandomOTP(int iOTPLength, string[] saAllowedCharacters)
        //{
        //    string sOTP = String.Empty;
        //    string sTempChars = String.Empty;
        //    Random rand = new Random();
        //    for (int i = 0; i < iOTPLength; i++)
        //    {
        //        int p = rand.Next(0, saAllowedCharacters.Length);
        //        sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];
        //        sOTP += sTempChars;
        //    }
        //    return sOTP;
        //}

        public string GenerateOtp()
        {
            string numbers = "0123456789";
            Random objrandom = new Random();
            string strrandom = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                int temp = objrandom.Next(0, numbers.Length);
                strrandom += temp;
            }
            return strrandom;
        }



        public string AddOTP(string EmailId, OtpTypeEnum OTPType)
        {
            Models.OtpIdentityVerification identityVerification = new Models.OtpIdentityVerification();
            string VerificationCode = "";
           
            try
            {
               // string generatedOtp = GenerateOtp();
                string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
#if RELEASE
               // VerificationCode = GenerateRandomOTP(6, saAllowedCharacters);
                
#elif DEBUG
                VerificationCode = "123456";
              // VerificationCode = generatedOtp;

#endif
                string salt = Utilities.SaltHash.Createsalt(6);
                string hash = Utilities.SaltHash.CreateHash(VerificationCode, salt);
                identityVerification.EmailId = EmailId;
                identityVerification.OTPHash = hash;
                identityVerification.OTPSalt = salt;
                identityVerification.OTPType = OtpTypeEnum.Registration;
                identityVerification.IsOTPVerified = false;
                _dbContext.OtpIdentityVerifications.Add(identityVerification); 
                _dbContext.SaveChanges();
                Utilities.SendMail.SendEmailToUser(EmailId, VerificationCode);
            }
            catch (Exception ex)
            {
                throw;
            }
            return VerificationCode;
        }

        public bool VerifyOTP(string emailID, string OTP)
        {
            bool isOTPVerified = false;
            try
            {
                var identityVerificationDetails = _dbContext.OtpIdentityVerifications.Where(s => s.EmailId.Equals(emailID)).First();
                if (identityVerificationDetails != null)
                {
                    if (!string.IsNullOrEmpty(identityVerificationDetails.OTPSalt) && !string.IsNullOrEmpty(OTP))
                    {

                        string otpHash = Utilities.SaltHash.CreateHash(OTP, identityVerificationDetails.OTPSalt);

                        if (identityVerificationDetails.OTPHash == otpHash)
                        {
                            identityVerificationDetails.IsOTPVerified = true;
                            _dbContext.SaveChanges();
                            isOTPVerified = true;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return isOTPVerified;
        }


    }
}
