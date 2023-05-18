using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Models
{
    public class EducationalDetails
    {
        [Key]
        public int EducationDetailsId { get; set; }
        public int EnrollId { get; set; }
        public string MetriculationBoard { get; set; }
        public string MetriculationRollNumber { get; set; }
        public DateTime YearOfPassingOfMetriculation { get; set; }
        public string GPAOfMetriculation { get; set; }
        public string IntermediateBoard { get; set; }
        public string IntermediateRollNumber { get;set; }
        public DateTime YearOfPassingOfIntermediate { get; set; }
        public string GPAOfIntermediate { get; set; }
        public string Graduation { get; set; }
        public string GraduationRollNumber { get; set; }
        public DateTime YearOfPassingOfGraduation { get; set; }
        public string GPAOfGraduation { get; set; }
        public string Photo { get; set; }
       


    }
}
