using CabBook.Model.Models;
using CabBook.Model.Models.Identity;
using CabBook.Service;
using CabBook.Web.App_Start;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CabBook.Web.Controllers
{
    [Authorize]
    public class RiderController : Controller
    {
        private readonly IRiderService riderService;

        private ApplicationSignInManager _signInManager;
        private AppUserManager _userManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public AppUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public RiderController(AppUserManager userManager, ApplicationSignInManager signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public RiderController(IRiderService riderService)
        {
            this.riderService = riderService;
        }

        // GET: Rider
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<ActionResult> ViewRides()
        {
            List<RideDetails> rideList = new List<RideDetails>();
            rideList = riderService.GetAllData().ToList();
            for (int i = 0; i < rideList.Count; i++)
            {
                var Driver = await UserManager.FindByIdAsync(rideList[i].UserDetails.Id);
                rideList[i].UserDetails = Driver;
            }
            return View(rideList);
        }

        [HttpPost]
        public ActionResult SendEnquiry(RideDetails model)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("");//("your_email_address@gmail.com");
                mail.To.Add(model.ToEmail);
                mail.Subject = "Car Enquiry";
                mail.Body = "Hello,<br/>" + "Name : " + model.RiderName + ",<br/>" + "Email Address" + model.RiderEmail + ",<br/>" + "Phone Number" + model.PhoneNumber;
                mail.IsBodyHtml = true;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential();//"Senderemail@gmail.com", "senderpassword");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("ViewRides", "Rider");
        }
    }
}