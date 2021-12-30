using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApplication.Models;
using CustomerApplication.DAl;

namespace CustomerApplication.Controllers
{
    
    public class CustomerController : Controller
    {
        IDAL dal = null;

        public CustomerController(IDAL _IDAl)
        {
            dal = _IDAl;
        }

        public IActionResult LoadCustomer()
        {
            return View("CustomerScreen");
        }
        // will get invoked when add button is clicked 

        public IActionResult Add([FromServices]Customer obj)  // automatically data will bind to the model if name and properties same 
        {
            //Customer obj = new Customer();// manual way to get the data 
            //obj.CustomerName = Request.Form["CustomerName"]; 
            //obj.CustomerCode = Request.Form["CustomerCode"];
            //obj.CustomerAmount = Convert.ToDouble(Request.Form["CustomerAmount"]);
            return View("DisplayCustomer",obj);
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
