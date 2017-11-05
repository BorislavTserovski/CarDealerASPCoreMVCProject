using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarDealer.Services;

namespace CarDealer.Controllers
{
    public class CustomersController : Controller
    {
       private ICustomerService customers;

        public CustomersController(ICustomerService customers)
        {
            this.customers = customers;
        }


       [Route("/customers/all/{order}")]
       public IActionResult All(string order)
        {
            return View(this.customers.All(order));
        }

        [Route("/customers/{id}")]
        public IActionResult CustomersSales(int id)
        {
            return View(this.customers.CustomerWithCars(id));
        }
    }
}