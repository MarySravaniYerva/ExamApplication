
using EA.IBussinessLogic;
using EA.Models;
using EA.Repository;
using EA.ViewModels;
using ExamApplication.Models;
using ExamApplication.Sessions;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ExamApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEnrollmentService _enrollmentService;
        private readonly ILoginservice _loginService;
        private readonly IAdmitCardService _admitCardService;
        public static IHttpContextAccessor _context;
        CreateSession createSession = new CreateSession(_context);
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IEnrollmentService enrollmentService, ILoginservice loginService, IAdmitCardService admitCardService,IHttpContextAccessor context, IConfiguration configuration)
        {
            _logger = logger;
            _enrollmentService = enrollmentService;
            _loginService = loginService;
            _admitCardService = admitCardService;
            _context = context;
            _configuration = configuration;

        }
        //public void CheckLogin()
        //{
        //    var enrollID = Convert.ToInt32(HttpContext.Session.GetString("EnrollId"));
        //    int res = _loginService.CheckLogin(enrollID);
        //    if(res != 0)
        //    {
        //        ViewBag.EnrollID = "{res}";
        //    }

        //}

        [HttpPost]
        public IActionResult SendEnrollmentOTP(string emailId)
        {
            if (ModelState.IsValid)
            {
                var OTPType = OtpTypeEnum.Registration;
                _enrollmentService.SendOTP(emailId, OTPType);
                return Ok();
            }
            return BadRequest();

        }


        [HttpPost]
        public IActionResult VerifyOTP(string emailId, string OTP)
        {
            var IsOTPVerified = _enrollmentService.VerifyOTP(emailId, OTP);
            return Json(IsOTPVerified);
        }


        [HttpGet]
        public IActionResult Enrollment()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Enrollment(EnrollmentViewModel enrollmentViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var enrollStatus = _enrollmentService.Enrollment(enrollmentViewModel);

                    if (enrollStatus != 0)
                    {
                        var enrollId = _enrollmentService.GetEnrollmentId(enrollmentViewModel);
                        ViewBag.enrollStatus = $"Login Successful and your enrollment id is {enrollId}.This has to be used when you downLoad your admit card.So please note the enrollment Id ";
                        return View();
                    }
                    else
                    {
                        ViewBag.enrollStatus = "Login Failed";
                        return View();
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public IActionResult Home()
        {
            return View();

        }
       

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string emailId, string password)
        {
            int enrollId= _loginService.Login(emailId, password);
            if(enrollId != 0)
            {
                HttpContext.Session.SetString("EnrollId", enrollId.ToString());
                SessionUser user = new SessionUser();
                user.Id = enrollId;
                createSession.SetSession(user, "SessionUser");
               // ViewBag.Login = "Login Successfull";
                return View("Apply","Home");
               
            }
            else
            {
                ViewBag.Login = "Invalid Credentials";
                return View();
            }           
        }

        [HttpGet]
        public IActionResult Apply()
        {        
                return View();
        }
        [HttpGet]
        [HttpGet]
        public IActionResult Result()
        {
            return View();
        }
      



        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgotPassword(EnrollmentViewModel enrollmentViewModel)
        {
            _loginService.UpdatePassword(enrollmentViewModel);
            return RedirectToAction("Login","Home");
        }
        [HttpPost]
        public IActionResult ForgotPasswordOTP(string emailId)
        {
            var OTP = OtpTypeEnum.ForgotYourPassword;
            var res =  _loginService.CheckEmailForPasswordChange(emailId);
            if(res != false)
            {
                _enrollmentService.SendOTP(emailId, OTP); 
                return Ok();
            }
            ViewBag.InvalidEmail = "Invalid Email Address";
            return View();           

        }
        [HttpPost]
        public IActionResult VerifyOTPforPasswordChange(string emailId, string OTP)
        {
            var isOtpVerified = _enrollmentService.VerifyOTP(emailId, OTP);
            return Json(isOtpVerified);
        }



       
        public IActionResult Logout()
        {
            try
            {
                //HttpContext.Session.Set(key: "msg", value: "");
                //createSession.SetSession(new SessionUser(), "SessionUser");
                HttpContext.Session.Clear();
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult AdmitCard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DetailsFilledforAdmitCard()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DetailsFilledforAdmitCard(int enrollId, string emailId, DateTime dateOfBirth)
        {
            var enrollID = Convert.ToInt32(HttpContext.Session.GetString("EnrollId"));
            var res = _admitCardService.DetailsCheckForAdmitCard(enrollId, emailId, dateOfBirth);
            if (res != 0)
            {
                ViewBag.DetailsAdmitCard = "Details Verified";
            }
            else
            {
                ViewBag.DetailsAdmitCard = "Incorrect Details";
            }
            return RedirectToAction("GenerateAdmitCard", new {EnrollId = enrollId , EmailID = emailId, DOB = dateOfBirth});
        }
        [HttpGet]
        public IActionResult GenerateAdmitCard(int EnrollId, string EmailID, DateTime DOB)
        {
            var admitCardDetails = _admitCardService.GenerateAdmitCard(EnrollId, EmailID, DOB);
            //if(admitCardDetails != null)
            //{
            //    string filepath = _configuration["FilePath:PhotoPath"].ToString();
                
            //}
            return View(admitCardDetails);
        }









        //public IActionResult GeneratePaySlip(int id)
        //{
        //    try
        //    {
        //        if (id != 0)
        //        {
        //            GetEmployeeRole();
        //            EmployeePaySlipDetails paySlipDetails = _employeeDocumentService.GetEmployeePaySlipDetailsService(id);
        //            if (paySlipDetails != null)
        //            {
        //                string filepath = _configuration["FilePath:GeneratedPaySlipPath"].ToString();
        //                Services services = new Services();
        //                paySlipDetails.AmountInWords = ConvertAmount(Convert.ToDouble(paySlipDetails.NetPay));
        //                var htmldata = services.PostAsync<object, string>("http://localhost:10697/Home/PaySlipGenerator", paySlipDetails).Result;
        //                //var htmldata = this.RenderViewAsync("~/Views/Home/Index", paySlipDetails).Result;
        //                HtmlToPdf htmlToPdf = new HtmlToPdf();
        //                htmlToPdf.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
        //                PdfDocument pdfDocument = htmlToPdf.ConvertHtmlString(htmldata);
        //                pdfDocument.Save(Path.Combine(filepath, paySlipDetails.EmpID + "_" + paySlipDetails.Name + "_" + paySlipDetails.Month + ".pdf"));
        //                pdfDocument.Close();
        //            }
        //        }
        //        return Ok();
        //    }
        //    catch (Exception ex) { throw ex; }
        //}
    }
}
