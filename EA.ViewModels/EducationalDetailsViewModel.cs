using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.ViewModels
{
    public class EducationalDetailsViewModel
    {
        public int EducationDetailsId { get; set; }
        [Required]
        public string MetriculationBoard { get; set; }
        [Required]
        //[RegularExpression(@"(^[2-9]{1}[0-9]{9}$)", ErrorMessage = "Invalid Metriculation Roll Number")]
        public string MetriculationRollNumber { get; set; }
        [Required]
        public DateTime YearOfPassingOfMetriculation { get; set; }
        [Required]
        public string GPAOfMetriculation { get; set; }
        [Required]
        public string IntermediateBoard { get; set; }
        [Required]
        //[RegularExpression(@"(^[2-9]{1}[0-9]{9}$)", ErrorMessage = "Invalid Intermediate Roll Number")]

        public string IntermediateRollNumber { get; set; }
        [Required]
        public DateTime YearOfPassingOfIntermediate { get; set; }
        [Required]
        public string GPAOfIntermediate { get; set; }
        [Required]
        public string Graduation { get; set; }
        [Required]
        //[RegularExpression(@"(^[2-9]{1}[0-9]{9}$)", ErrorMessage = "Invalid Graduation Roll Number")]

        public string GraduationRollNumber { get; set; }
        [Required]
        public DateTime YearOfPassingOfGraduation { get; set; }
        [Required]
        public string GPAOfGraduation { get; set; }
        public IFormFile Photo { get; set; }
        public string PhotoPath { get; set; }
    }
}
