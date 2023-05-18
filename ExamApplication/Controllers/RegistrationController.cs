using EA.BusinessLogic;
using EA.IBussinessLogic;
using EA.Repository;
using EA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace ExamApplication.Controllers
{
    public class RegistrationController:Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRegistrationService _registrationService;
        private readonly IConfiguration _configuration;
        private readonly ILoginservice _loginService;

        public RegistrationController(ILogger<HomeController> logger, IRegistrationService registrationService,IConfiguration configuration, ILoginservice loginservice)
        {
            _logger = logger;
            _registrationService = registrationService;
            _configuration = configuration;
            _loginService = loginservice;
        }
        [HttpGet] 
        public IActionResult BasicDetails() 
        {
          
                return View();
        }
          
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BasicDetails(BasicDetailsViewModel basicDetailsViewModel)
        {
            try
            {
                    if (ModelState.IsValid)
                    {
                        _registrationService.GetBasicDetails(basicDetailsViewModel);
                        return RedirectToAction("EducationalDetails", "Registration");
                        //return View();
                    }
                return View();
               
            }
            catch (Exception ex) 
            {
                throw ex;
            }
          
        }
        [HttpGet]
        public IActionResult EducationalDetails()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EducationalDetails(EducationalDetailsViewModel educationalDetailsViewModel)
        {
            
                // if (ModelState.IsValid)
                //{
                try
                {

                  educationalDetailsViewModel.Photo= Request.Form.Files[0];
                     Regex reg = new Regex("([a-zA-Z0-9\\s_\\\\.\\-\\(\\):])+(.jpg|.JPG|.png|.PNG|.jpeg|.JPEG)$");
                    if (reg.IsMatch(educationalDetailsViewModel.Photo.FileName))
                    {
                    string photoPath = _configuration["FilePath:PhotoPath"].ToString();
                    string path = (Path.Combine(photoPath,"-" + educationalDetailsViewModel.Photo.FileName)).ToString();
                    educationalDetailsViewModel.PhotoPath = path;
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        educationalDetailsViewModel.Photo.CopyTo(stream);
                    }
                   int success= _registrationService.GetEducationalDetails(educationalDetailsViewModel);
                    if (success != 0)

                        ViewBag.success = "Document Uploaded Successfully";
                    else
                        ViewBag.success = "Document doesn't Uploaded";
                      }
                else
                {
                    ViewBag.File = "Please Upload PDF / Document type file only";
                }
                    return View();
                
                    
               // return View();
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       

    }
}
