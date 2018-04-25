using CabBook.Model.Models;
using CabBook.Service;
using CabBook.Web.App_Start;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CabBook.Web.WebAPI
{
    //[Route("api/Driver")]
    [Authorize]
    public class DriverAPIController : ApiController
    {
        private readonly IDriverService driverService;
        private readonly ICarDeatilsService cardetailsservice;
        private readonly IRiderService riderService;

        public DriverAPIController()
        {

        }

        public DriverAPIController(IDriverService driverService, ICarDeatilsService cardetailsservice, IRiderService riderservice)
        {
            this.driverService = driverService;
            this.cardetailsservice = cardetailsservice;
            this.riderService = riderservice;
        }
        private ApplicationSignInManager _signInManager;
        private AppUserManager _userManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
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
        public DriverAPIController(AppUserManager userManager, ApplicationSignInManager signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;


        }
        [Route("PostRide/{ID}")]
        [HttpGet]
        public CarDetails PostRide(string ID)
        {
            var carDetails = cardetailsservice.GetCarDetailsByDriverId(ID);
            return carDetails;
        }

        [Route("api/Driver/PostRide")]
        [HttpPost]
        public string PostRide(RideInformation model)
        {
            var Result = "";
            model.Id = Guid.NewGuid();
            model.UserId = model.UserId;
            model.Active = true;
            if (ModelState.IsValid)
            {
                try
                {
                    driverService.DiactiveotherRides(model.UserId);
                    driverService.CreateData(model);
                    driverService.SaveData();
                    Result = "Success";
                }
                catch (Exception e)
                {
                    Result = "Failed";
                }
            }
            else
            {
                Result = "Invalid Input";
            }
            return Result;
        }

        [Authorize]
        [Route("api/Driver/CarDetails/{UserId}")]
        [HttpGet]
        public CarDetails CarDetails(string UserId)
        {
            var carDetails = cardetailsservice.GetCarDetailsByDriverId(UserId);
            return carDetails;
        }

        [Route("api/Driver/CarDetails")]
        [HttpPost]
        public string CarDetails(CarDetails model)
        {
            model.Id = Guid.NewGuid();
            model.UserId = model.UserId;
            
                try
                {
                    cardetailsservice.CreateData(model);
                    cardetailsservice.SaveData();
                    return "Success";
                }
                catch (Exception e)
                {
                    return "Error";
                }
            
        }

        [Authorize]
        [Route("api/Driver/ViewRides/{id}")]
        [HttpGet]
        public List<RideInformation> ViewRides(string id)
        {
            List<RideInformation> rideList = new List<RideInformation>();
            rideList = riderService.GetDatabyDriverId(id);
            return rideList;
        }

        [Authorize()]
        //api/Driver/GetUserFromToken
        [Route("api/Driver/GetUserFromToken")]
        [HttpGet]
        public IHttpActionResult GetUserFromToken()
        {

            var u = User;
            UserManager.FindByIdAsync(u.Identity.Name);
            var id = RequestContext.Principal.Identity.GetUserId();
            return Ok(u);
        }

    }
}
