using EA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.IBussinessLogic
{
    public interface IAdmitCardService
    {
        int DetailsCheckForAdmitCard(int enrollId, string emailId, DateTime dateOfBirth);
        AdmitCardModel GenerateAdmitCard(int EnrollId, string EmailID, DateTime DOB);
    }
}
