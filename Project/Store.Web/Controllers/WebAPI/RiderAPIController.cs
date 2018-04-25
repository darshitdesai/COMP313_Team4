using CabBook.Data.Infrastructure;
using CabBook.Data.Repositories;
using CabBook.Model.Models;
using CabBook.Service;
using CabBook.Web.App_Start;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CabBook.Web.WebAPI
{
    [Authorize]
    public class RiderAPIController : ApiController
    {
        private readonly IRiderService riderService;

        private readonly IRiderRepository riderRepository;
        private readonly IDriverRepository driverRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICarDetailsRepository carDetailsRepository;

        public RiderAPIController(IRiderRepository riderRepository, IUnitOfWork unitOfWork, IDriverRepository driverRepository, ICarDetailsRepository carDetailsRepository, IRiderService riderService)
        {
            this.riderRepository = riderRepository;
            this.driverRepository = driverRepository;
            this.carDetailsRepository = carDetailsRepository;
            this.unitOfWork = unitOfWork;
            this.riderService = riderService;
        }

        private ApplicationSignInManager _signInManager;
        private AppUserManager _userManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ??  HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
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
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public RiderAPIController(AppUserManager userManager, ApplicationSignInManager signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public RiderAPIController(IRiderService riderService)
        {
            this.riderService = riderService;
        }

        //[AllowAnonymous]
        //[Route("api/Rider/GetAllData")]
        //[HttpGet]
        //public IEnumerable<RideDetails> GetAllData()
        //{
        //    var data = new List<RideDetails>();

        //    var allDrivers = riderRepository.GetAll();

        //    foreach (var driver in riderRepository.Drivers())
        //    {
        //        var rideDetail = new RideDetails();
        //        rideDetail.rideInfo = driverRepository.GetByDriverId(driver.Id);
        //        rideDetail.carDetails = carDetailsRepository.GetDetailsByDriverId(driver.Id);
        //        rideDetail.UserDetails = driver;

        //        data.Add(rideDetail);
        //        //data.Add(driver.rideInfo)
        //    }

        //    return data;
        //}


        [AllowAnonymous]
        [Route("api/Rider/GetAllData")]
        [HttpGet]
        public async Task<IEnumerable<RideDetails>> GetAllData()
        {
            List<RideDetails> rideList = new List<RideDetails>();
            rideList = riderService.GetAllData().ToList();
            for (int i = 0; i < rideList.Count; i++)
            {
                var Driver = await UserManager.FindByIdAsync(rideList[i].UserDetails.Id);
                rideList[i].UserDetails = Driver;
            }
            return rideList;
        }

        //[HttpGet]
        //public async Task<List<RideDetails>> ViewRides()
        //{
        //    List<RideDetails> rideList = new List<RideDetails>();
        //    rideList = riderService.GetAllData().ToList();
        //    for (int i = 0; i < rideList.Count; i++)
        //    {
        //        var Driver = await UserManager.FindByIdAsync(rideList[i].UserDetails.Id);
        //        rideList[i].UserDetails = Driver;
        //    }
        //    return rideList;
        //}

        [AllowAnonymous]
        [Route("api/Rider/SendEnquiry")]
        [HttpPost]
        public string SendEnquiry(RideDetails model)
        {
            //get user by id

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
                return "Error";
            }
            return "Success";
        }
    }
}
