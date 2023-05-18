using AutoMapper;
using EA.Database;
using EA.Models;
using EA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly ExamApplicationDbContext _dbContext;
        public RegistrationRepository(ExamApplicationDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        public void getBasicDetails(BasicDetailsViewModel basicDetailsView)
        {
            try
            {
                
                BasicDetails basic = new BasicDetails();
                //basic.Aadhaar = basicDetailsView.Aadhaar;
                //basic.FullAddress = basicDetailsView.FullAddress;
                //basic.FirstName = basicDetailsView.FirstName;
                //basic.LastName = basicDetailsView.LastName;
                //basic.MotherName = basicDetailsView.MotherName;
                //basic.FatherName = basicDetailsView.FatherName;
                //basic.PhoneNumber = basicDetailsView.PhoneNumber;
                var config = new MapperConfiguration(cfg => cfg.CreateMap<BasicDetailsViewModel, BasicDetails>());
                var mapper = config.CreateMapper();
                basic = mapper.Map<BasicDetails>(basicDetailsView);
                //basic.DOB = basicDetailsView.DOB;
                //basic.EmailId = basicDetailsView.EmailId;
                //basic.Gender = basicDetailsView.Gender;
                
                //_dbContext.Add(basic);
                _dbContext.BasicDetails.Add(basic);
                _dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
     
        }
       
        public int GetEducationalDetails(EducationalDetailsViewModel educationalDetailsViewModel)
        {
            try
            {
                EducationalDetails educationalDetails = new EducationalDetails();
                if (educationalDetailsViewModel != null)
                {
                    educationalDetails.MetriculationBoard = educationalDetailsViewModel.MetriculationBoard;
                    educationalDetails.MetriculationRollNumber = educationalDetailsViewModel.MetriculationRollNumber;
                    educationalDetails.GPAOfMetriculation = educationalDetailsViewModel.GPAOfMetriculation;
                    educationalDetails.YearOfPassingOfMetriculation = educationalDetailsViewModel.YearOfPassingOfMetriculation;
                    educationalDetails.IntermediateBoard = educationalDetailsViewModel.IntermediateBoard;
                    educationalDetails.IntermediateRollNumber = educationalDetailsViewModel.IntermediateRollNumber;
                    educationalDetails.GPAOfIntermediate = educationalDetailsViewModel.GPAOfIntermediate;
                    educationalDetails.YearOfPassingOfIntermediate = educationalDetailsViewModel.YearOfPassingOfIntermediate;
                    educationalDetails.Graduation = educationalDetailsViewModel.Graduation;
                    educationalDetails.GraduationRollNumber = educationalDetailsViewModel.GraduationRollNumber;
                    educationalDetails.GPAOfGraduation = educationalDetailsViewModel.GPAOfGraduation;
                    educationalDetails.YearOfPassingOfGraduation = educationalDetailsViewModel.YearOfPassingOfGraduation;
                    educationalDetails.Photo = educationalDetailsViewModel.PhotoPath;
                }
                _dbContext.EducationalDetails.Add(educationalDetails);              
                var uploaded = _dbContext.SaveChanges();
                if (uploaded != null)
                    return 1;
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       
    }
}
