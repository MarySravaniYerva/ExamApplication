using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Models
{
    public class AdmitCardModel
    {
        [Key]
        public int AdmitCardId {  get; set; }
        public int EnrollId { get; set; }
        public string HallTicketNumber { get; set; }
        public string CandidateName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ExamDate { get; set; }
        public string ExamDuration { get; set; }     
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string FullAddress { get; set; }
        public string CenterAddress { get; set; }
        public string Photo { get; set; }
        public string? Signature { get; set; }


    }
}
