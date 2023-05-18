using EA.Database;
using EA.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Repository
{
    public class AdmitCardRepository : IAdmitCardRepository
    {
        private readonly ExamApplicationDbContext _dbContext;
        public AdmitCardRepository(ExamApplicationDbContext DbContext)
        {
            _dbContext = DbContext;
        }

       
        public int DetailsCheckForAdmitCard(int enrollId, string emailId, DateTime dateOfBirth)
        {
            var res = _dbContext.Enrollments.Where(x => x.EnrollId == enrollId && x.EmailId == emailId && x.DateOfBirth == dateOfBirth).FirstOrDefault();
            if (res != null)
            {
                return 1;
            }
            return 0;

        }

    }
}
