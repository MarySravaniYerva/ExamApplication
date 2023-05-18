using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.ViewModels
{
    public class BasicDetailsViewModel
    {
        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Your First Name must be Characters")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Your Last Name must be Characters")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Your Father Name must be Characters")]
        public string FatherName { get; set; }
        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Your Mother Name must be Characters")]
        public string MotherName { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailId { get; set; }
        [Required]
        [RegularExpression(@"(^[2-9]{1}[0-9]{11}$)", ErrorMessage = "Invalid Aadhaar number")]
        public string Aadhaar { get; set; }
        [Required]
        [RegularExpression(@"(^[6 - 9]\d{9}$)", ErrorMessage = "Invalid mobile number")]
        public string PhoneNumber { get; set; }
        [Required]
        public string FullAddress { get; set; }
       
    }
}
