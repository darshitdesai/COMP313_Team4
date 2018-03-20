using CabBook.Model.Models;
using CabBook.Web.App_Start;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CabBook.Service;

namespace CabBook.Web.Controllers
{
    public class DriverController : Controller
    {
        // GET: Driver
        //private AppUserManager _userManager;
        private readonly IDriverService driverService;
        private readonly ICarDeatilsService cardetailsservice;
        private readonly IRiderService riderService;
        //public DriverController(AppUserManager usermanager, IDriverService driverService)
        //{
        //    UserManager = usermanager;
        //    this.driverService = driverService;
        //}

        public DriverController(IDriverService driverService, ICarDeatilsService cardetailsservice, IRiderService riderservice)
        {
            this.driverService = driverService;
            this.cardetailsservice = cardetailsservice;
            this.riderService = riderservice;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PostRide()
        {
            var carDetails = cardetailsservice.GetCarDetailsByDriverId(User.Identity.GetUserId());
            if(carDetails == null)
            {
                TempData["Message"] = "RidePost";
                TempData["Message"] = "Please Enter Your Car Details";
                return RedirectToAction("CarDetails", "Driver");
            }
            return View("Driver");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult PostRide(RideInformation model)
        {
            model.Id = Guid.NewGuid();
            model.UserId = User.Identity.GetUserId();
            model.Active = true;
            if (ModelState.IsValid)
            {
                try
                {
                    driverService.DiactiveotherRides(model.UserId);
                    driverService.CreateData(model);
                    driverService.SaveData();
                    TempData["Message"] = "Ride Post Succesfully";
                }
                catch (Exception e)
                {

                }
            }
            return RedirectToAction("Index", "Driver");
        }

        //public AppUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}

        public ActionResult CarDetails()
        {
            var carDetails = cardetailsservice.GetCarDetailsByDriverId(User.Identity.GetUserId());
            return View("CarDetails", carDetails);
        }

        [HttpPost]
        public ActionResult CarDetails(CarDetails model)
        {
            model.Id = Guid.NewGuid();
            model.UserId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                try
                {
                    cardetailsservice.CreateData(model);
                    cardetailsservice.SaveData();
                    TempData["Message"] = "Car Details Add Successfully";
                }
                catch (Exception e)
                {

                }
            }
            else
            {
                TempData["Message"] = "Enter Required Details";
                return RedirectToAction("CarDetails", "Driver");
            }
            return RedirectToAction("CarDetails", "Driver");
        }

        public ActionResult ViewRides()
        {
            List<RideInformation> rideList = new List<RideInformation>();
            rideList = riderService.GetDatabyDriverId(User.Identity.GetUserId());
            return View("viewRides",rideList);
        }

    }
}