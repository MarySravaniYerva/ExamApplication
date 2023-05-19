using EA.IBussinessLogic;
using EA.IRepository;
using EA.Models;
using EA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.BusinessLogic
{
    public class AdmitCardService : IAdmitCardService
    {
        private readonly IAdmitCardRepository _admitCardRepository;
        public AdmitCardService(IAdmitCardRepository admitCardRepository)
        {
            _admitCardRepository = admitCardRepository;
        }
        public int DetailsCheckForAdmitCard(int enrollId, string emailId, DateTime dateOfBirth)
        {
            var res = _admitCardRepository.DetailsCheckForAdmitCard(enrollId, emailId, dateOfBirth);
            return res;
        }
        public AdmitCardModel GenerateAdmitCard(int EnrollId, string EmailID, DateTime DOB)
        {
            var admitCardInfo = _admitCardRepository.GenerateAdmitCard(EnrollId, EmailID, DOB);
            return admitCardInfo;    
        }

    }
}
