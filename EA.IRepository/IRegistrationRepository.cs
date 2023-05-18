using EA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Repository
{
    public interface IRegistrationRepository
    {
        void getBasicDetails(BasicDetailsViewModel basicDetailsView);
        int GetEducationalDetails(EducationalDetailsViewModel educationalDetailsViewModel);
     
    }
}
