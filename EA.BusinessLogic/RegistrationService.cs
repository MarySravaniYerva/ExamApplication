using EA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Repository
{
    public  class RegistrationService :IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;
        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }
        public void GetBasicDetails(BasicDetailsViewModel basicDetailsViewModel)
        {
            try
            {
                _registrationRepository.getBasicDetails(basicDetailsViewModel);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public int GetEducationalDetails(EducationalDetailsViewModel basicDetailsViewModel)
        {
            try
            {
                return _registrationRepository.GetEducationalDetails(basicDetailsViewModel);

            }
            catch(Exception ex)
            {
                throw ex;
                return 0;
            }
        }

      
    }
}
