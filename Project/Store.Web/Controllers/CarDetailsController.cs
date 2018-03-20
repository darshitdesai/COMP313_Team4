using CabBook.Model.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CabBook.Service;

namespace CabBook.Web.Controllers
{
    public class CarDetailsController : Controller
    {
        private readonly ICarDeatilsService cardetailsservice;

        public CarDetailsController(ICarDeatilsService cardetailsservice)
        {
            this.cardetailsservice = cardetailsservice;
        }

        // GET: CarDetails
        public ActionResult Index()
        {
            return View("~/Views/Home/Driver.cshtml");
        }

        public ActionResult CarDetails()
        {
            return View("CarDetails");
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
                }
                catch (Exception e)
                {

                }
            }
            return RedirectToAction("Index");
        }
    }
}