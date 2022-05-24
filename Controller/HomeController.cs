using Clinic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace Clinic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //[HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        //[ValidateAntiForgeryToken]
        //[HttpPost]
        public IActionResult IndexPage(Login log)
        {
            if (ModelState.IsValid)
            {
                Login lobj = new Login();
                int result = lobj.validation(log);
                if (result == 1)
                {
                    return View("Home");
                }
                
            }
            return View("Invalid");
        }
        public IActionResult Home()
        {
            return View();
        }

       
        public IActionResult AddDoctor()
        {
            return View();
        }
        public IActionResult Doctor(AddDoc Doc)
        {
            if(ModelState.IsValid)
            { 

            AddDoc cobj = new AddDoc();
            int result = cobj.Docpro(Doc);
            if (result == 1)
                return View("DocSuccess");
            }            
            return View("AddDoctor");
        }


        public IActionResult AddPatient()
        {
            return View();
        }
        public IActionResult Patient(AddPat pat)
        {
            if(ModelState.IsValid)
            { 
            AddPat pobj = new AddPat();
            int result = pobj.Patpro(pat);
            if (result == 1)
                return View("DocSuccess");
            }           
                return View("AddPatient");
        }



        public IActionResult ScheduleAppointment()
        {
            return View();
        }
        public IActionResult Schedule(ScheduleApp sat)
        {
            if(ModelState.IsValid)
            { 
            ScheduleApp sobj = new ScheduleApp();
            int result = sobj.Schedulepro(sat);
            if (result == 1)
                return View("ScheduleSuccess");
            }
                return View("ScheduleAppointment");
        }
       

       
        public IActionResult CancelAppointment()
        {
            return View();
        }
        public IActionResult Cancel(CancelApp cat)
        {
            if(ModelState.IsValid)
            { 
            CancelApp cobj = new CancelApp();
            int result = cobj.Cancelpro(cat);
            if (result == 1)
                return View("CancelSuccess");
            }
                return View("CancelAppointment");
        }
        
       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
