using AutoMapper;
using CabBook.Data;
using CabBook.Data.Infrastructure;
using CabBook.Model;
using CabBook.Model.Models;
using CabBook.Model.Models.Identity;
using CabBook.Service;
using CabBook.Web.App_Start;
using CabBook.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace CabBook.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDemoService demoService;
        public HomeController(IDemoService demoService)
        {
            this.demoService = demoService;
        }
        private ApplicationSignInManager _signInManager;
        private AppUserManager _userManager;
        public HomeController(AppUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
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

        //[Authorize]
        // GET: Home

        [AllowAnonymous]

        public ActionResult Index()
        {
            AppUser user = UserManager.FindByName(User.Identity.Name);
            if (User.Identity.IsAuthenticated)
            {
                if (UserManager.IsInRole(user.Id, "Rider"))
                {
                    return RedirectToAction("Index", "Rider");
                }
                else if (UserManager.IsInRole(user.Id, "Driver"))
                {
                    return RedirectToAction("Index", "Driver");
                }
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {

            return View();
        }

        [AllowAnonymous]
        public ActionResult Home()
        {

            return View();
        }

        [Authorize]
        public ActionResult Rider()
        {
            return View();
        }

        [Authorize]
        public ActionResult Driver()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Demo newdata)
        {
            if (newdata != null)
            {
                demoService.CreateData(newdata);
                demoService.SaveData();
            }
            return RedirectToAction("Index");
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(ContactUs model)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("");//("your_email_address@gmail.com");
                mail.To.Add(model.EmailAddress);
                mail.Subject = model.Subject;
                mail.Body = "Hello,<br/>" + "Name : " + model.Name + ",<br/>" + "Details" + model.Body;
                mail.IsBodyHtml = true;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential();//"Senderemail@gmail.com", "senderpassword");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("ContactUs", "Home");
        }

        public ActionResult FeedBack()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FeedBack(FeedBack model)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("");//("your_email_address@gmail.com");
                mail.To.Add(model.EmailAddress);
                mail.Subject = "User Feedback";
                mail.Body = "Hello,<br/>" + "Name : " + model.Name + ",<br/>" + "Feedback : " + model.Feedback;
                mail.IsBodyHtml = true;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential();// "senderemail@gmail.com", "senderpassword");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("FeedBack", "Home");
        }
    }
}