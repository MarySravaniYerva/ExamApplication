using EA.Database;
using EA.IRepository;
using EA.Models;
using EA.ViewModels;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public string GenerateHallTicketNumber()
        {
            string numbers = "0123456789";
            Random objrandom = new Random();
            string strrandom = string.Empty;
            for (int i = 0; i < 10; i++)
            {
                int temp = objrandom.Next(0, numbers.Length);
                strrandom += temp;
            }
            return strrandom;
        }

        public AdmitCardModel GenerateAdmitCard(int EnrollId, string EmailID, DateTime DOB)
        {
            string hallTicketNUmber = "";

            AdmitCardModel admitCardModel = new AdmitCardModel();
            if (EnrollId != 0)
            {
                admitCardModel.EnrollId = EnrollId ;

                string HTnumber = GenerateHallTicketNumber();
                hallTicketNUmber = HTnumber;
                admitCardModel.HallTicketNumber = hallTicketNUmber;

                var firstName =(_dbContext.BasicDetails.Where(x => x.EnrollId == EnrollId).Select(x=>x.FirstName)).FirstOrDefault();
                var lastName = (_dbContext.BasicDetails.Where(x => x.EnrollId == EnrollId).Select(x => x.LastName)).FirstOrDefault();
                admitCardModel.CandidateName = firstName + " " + lastName;

                var gender = (_dbContext.BasicDetails.Where(x => x.EnrollId == EnrollId).Select(x => x.Gender)).FirstOrDefault();
                admitCardModel.Gender = gender;

                var dateOfBirth = (_dbContext.BasicDetails.Where(x => x.EnrollId == EnrollId).Select(x => x.DOB)).FirstOrDefault();
                admitCardModel.DateOfBirth = dateOfBirth;

                admitCardModel.ExamDate= "09-09-2023  08:30 am";
                admitCardModel.ExamDuration = "2hrs";

                var motherName = (_dbContext.BasicDetails.Where(x => x.EnrollId == EnrollId).Select(x => x.MotherName)).FirstOrDefault();
                admitCardModel.MotherName = motherName;

                var fatherName = (_dbContext.BasicDetails.Where(x => x.EnrollId == EnrollId).Select(x => x.FatherName)).FirstOrDefault();
                admitCardModel.FatherName = fatherName;

                var fullAddress = (_dbContext.BasicDetails.Where(x => x.EnrollId == EnrollId).Select(x => x.FullAddress)).FirstOrDefault();
                admitCardModel.FullAddress = fullAddress;

                admitCardModel.CenterAddress = " Aishwarya building, Survey 12, 13 & 14, GJ Colony, Ward No 3, Block No 2,Saroornagar Mdl., L.B.Nagar Circle to Sagar X Road, 3-2-126/7, Srisailam Hwy, beside Green Bawarchi, L. B. Nagar, Telangana 500074";

                var photo = (_dbContext.EducationalDetails.Where(x => x.EnrollId == EnrollId).Select(x => x.Photo)).FirstOrDefault();
                admitCardModel.Photo = photo;

                admitCardModel.Signature = "";

                
            }
            return admitCardModel;


        }

    }
}
