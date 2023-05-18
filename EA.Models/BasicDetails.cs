using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Models
{
    public class BasicDetails
    {
        [Key]
        public int BasicDetailsId { get; set; }
        public int EnrollId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string EmailId { get; set; }
        public string Aadhaar { get; set; }
        public string PhoneNumber { get; set; }
        public string FullAddress { get; set; }
 
    }
}