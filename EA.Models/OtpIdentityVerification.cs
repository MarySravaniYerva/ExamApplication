using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Models
{
    public class OtpIdentityVerification
    {
        [Key]
        public int OtpId { get; set; }
        public string EmailId { get; set; }
        public string OTPHash { get; set; }
        public string OTPSalt { get; set; }
        public OtpTypeEnum OTPType { get; set; }
        public bool IsOTPVerified { get; set; }

    }
}
