using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EA.Repository.Utilities
{
    public class SendMail
    {
        public static string EmployeeMailId = "mary.sravani@tekfriday.com";
        public static string EmployeeName = "Mary Sravani";
        public static void SendEmailToUser(string EmailId, string VerificationCode)
        {
            try
            {
                var senderEmail = new MailAddress(EmployeeMailId, EmployeeName);
                var password = "Mary@67589";
                var receiverEmail = new MailAddress(EmailId);
                //HRadmin or HR password
                var smtp = new SmtpClient
                {
                    Host = "smtp.ionos.com", //smtp.ionos.com
                    Port = 587,             //port number to be updated
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var sendMail = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = "Verification Code ",
                    Body = "Your confirmation code is below — " + VerificationCode + "."
                })
                {
                     //     smtp.Send(sendMail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
