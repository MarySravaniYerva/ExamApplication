using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.ViewModels
{
    public class EnrollmentViewModel
    {
        public int EnrollId { get; set; }
        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Your First Name must be Characters")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Your Last Name must be Characters")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailId { get; set; }

        [Required]
        [RegularExpression(@"(^[6 - 9]\d{9}$)", ErrorMessage = "Invalid mobile number")]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
       // [RegularExpression(@"^\d{4}\s\d{4}\s\d{4}$", ErrorMessage = "Invalid Aadhaar Number")]
        public string AadharNumber { get; set; }

        [Required]
        [RegularExpression(@"(?=.*\d)(?=.*[A-Za-z]).{5,}", ErrorMessage = "Your password must be at least 5 characters long and contain at least 1 letter and 1 number")]
        public string Password { get; set; }
    }
}
