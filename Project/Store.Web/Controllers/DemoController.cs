using AutoMapper;
using CabBook.Model.Models;
using CabBook.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CabBook.Web.Controllers
{
    public class DemoController : Controller
    {
        private readonly IDemoService demoService;
        // GET: Demo

        public DemoController(IDemoService demoService)
        {
            this.demoService = demoService;
        }
        public ActionResult Index()
        {
            IEnumerable<Demo> demodata;
            demodata = demoService.GeData();
            return View(demodata);
        }

        [HttpPost]
        public ActionResult Create(Demo demo)
        {
            if (demo != null)
            {
                demoService.CreateData(demo);
            }
            return RedirectToAction("Index");
        }
    }
}