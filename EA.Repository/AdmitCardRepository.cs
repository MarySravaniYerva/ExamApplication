using EA.Database;
using EA.IRepository;
using EA.Models;
using EA.ViewModels;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
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
            string numbers = "123456789";
            Random objrandom = new Random();
            string strrandom = string.Empty;
            for (int i = 1; i < 3; i++)
            {
                int temp = objrandom.Next(0, numbers.Length);
                strrandom += temp;
            }
            return strrandom;
        }

        public AdmitCardModel GenerateAdmitCard(int EnrollId, string EmailID, DateTime DOB)
        {

            AdmitCardModel model = new AdmitCardModel();
            if (EnrollId != 0)
            {
                string HTnumber = GenerateHallTicketNumber();
                
                var admitCardModel = (from enrollments in _dbContext.Enrollments.Where(x=>x.EnrollId == EnrollId)
                               join bd in _dbContext.BasicDetails
                               on enrollments.EnrollId equals bd.EnrollId into basicDetails from BDetails in basicDetails.DefaultIfEmpty()
                               join eduDetails in _dbContext.EducationalDetails on BDetails.EnrollId equals eduDetails.EnrollId into tempEduDetails from EduDetails in tempEduDetails.DefaultIfEmpty()
                               //where enrollments.EnrollId == EnrollId
                               select new AdmitCardModel
                               {
                                   EnrollId = enrollments.EnrollId,
                                   CandidateName = enrollments.FirstName + " " +enrollments.LastName, 
                                   Gender = BDetails !=null ? BDetails.Gender : "",
                                   FatherName = BDetails != null ? BDetails.FatherName : "",
                                   MotherName = BDetails != null ? BDetails.MotherName : "",
                                   FullAddress = BDetails != null ? BDetails.FullAddress : "",
                                   Photo = EduDetails !=null ? EduDetails.Photo : "",
                                   DateOfBirth = BDetails != null ? BDetails.DOB : DateTime.Now,
                                   Signature = "",
                                   HallTicketNumber = HTnumber,
                                   CenterAddress = " Aishwarya building, Survey 12, 13 & 14, GJ Colony, Ward No 3, Block No 2,Saroornagar Mdl., L.B.Nagar Circle to Sagar X Road, 3-2-126/7, Srisailam Hwy, beside Green Bawarchi, L. B. Nagar, Telangana 500074",
                                   ExamDate = "09-09-2023  08:30 am",
                                   ExamDuration = "2hrs",

                               }).FirstOrDefault();
                model = admitCardModel;
                if(model != null && model.EnrollId > 0)
                {
                    _dbContext.Add(model);
                    _dbContext.SaveChanges();
                }
            }            
            return model;
        }

    }
}
