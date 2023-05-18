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
    }
}
