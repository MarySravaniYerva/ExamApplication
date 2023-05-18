using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.IRepository
{
    public interface IAdmitCardRepository
    {
        int DetailsCheckForAdmitCard(int enrollId, string emailId, DateTime dateOfBirth);
    }
}
