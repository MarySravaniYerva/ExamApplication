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
    public class LoginRepository : ILoginRepository
    {
        private readonly ExamApplicationDbContext _dbContext;
        public LoginRepository(ExamApplicationDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public int CheckLogin(int enrollID)
        {
            int EnrollID = 0;
            var res = _dbContext.Enrollments.Where(x=>x.EnrollId == enrollID).FirstOrDefault();
            if(res != null)
            {
                 EnrollID = res.EnrollId;
                return EnrollID;
            }
            return 0;
        }
        public int Login(string emailId, string password)
        {
            var userLogin = _dbContext.Enrollments.Where(x => x.EmailId == emailId).FirstOrDefault();
            if (userLogin != null)
            {
                if (!string.IsNullOrEmpty(userLogin.PasswordSalt) && (!string.IsNullOrEmpty(userLogin.PasswordSalt)))
                {
                    string hashPassword = Utilities.SaltHash.CreateHash(password, userLogin.PasswordSalt);

                    if (userLogin.PasswordHash == hashPassword)
                    {
                        int enrollmentId = userLogin.EnrollId;
                        return enrollmentId;
                    }
                }
            }
            return 0;
        }


        public bool CheckEmailForPasswordChange(string emailId)
        {
            var userInfo = _dbContext.Enrollments.Where(s => s.EmailId == emailId).FirstOrDefault();
            if (userInfo != null)
            {
                return true;
            }
            return false;
        }

        public bool UpdatePassword(EnrollmentViewModel enrollmentViewModel)
        {
            var userDetails = _dbContext.Enrollments.Where(x => x.EmailId == enrollmentViewModel.EmailId).FirstOrDefault();
            if(userDetails != null)
            {
                string PasswordSalt = Utilities.SaltHash.Createsalt(20);
                string PasswordHash = Utilities.SaltHash.CreateHash(enrollmentViewModel.Password, PasswordSalt);
                userDetails.PasswordSalt = PasswordSalt;
                userDetails.PasswordHash = PasswordHash;
                _dbContext.SaveChanges();
                return true;

            }
            return false;
                
          
            
        }
    }
}
