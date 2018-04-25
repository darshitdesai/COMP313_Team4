using CabBook.Model.Models;
using CabBook.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CabBook.Web.WebAPI
{
    public class DemoController : ApiController
    {
        private readonly IDemoService demoService;
        public DemoController(IDemoService demoService)
        {
            this.demoService = demoService;
        }

        [Route("demoapi/index")]
        [HttpGet]
        public List<Demo> Index()
        {
            List<Demo> demodata;
            demodata = demoService.GeData().ToList();
            return demodata;
        }
    }
}
