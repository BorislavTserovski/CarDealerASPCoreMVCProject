using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarDealer.Services;
using CarDealer.Models.Customers;

namespace CarDealer.Controllers
{
    public class CustomersController : Controller
    {
       private ICustomerService customers;

        public CustomersController(ICustomerService customers)
        {
            this.customers = customers;
        }

        //GET
        public IActionResult Edit(int id)
        {
            return View(this.customers.Edit(id));
        }

        //POST
        [HttpPost]
        public IActionResult Edit(int id, CustomerModel model)
        {
            this.customers.Edit(id,model);
            return RedirectToAction("/all/ascending");
        }

        //GET
        public IActionResult Add()
        {
            return View();
        }

        //POST
        [HttpPost]
        [Route("/customers/add")]
        public IActionResult Add(string name, DateTime birthDate)
        {
            this.customers.Add(name, birthDate);
            return RedirectToAction("all/ascending");
        }


       [Route("/customers/all/{order}")]
       public IActionResult All(string order)
        {
            return View(this.customers.All(order));
        }

       // [Route("/customers/{id}")]
        public IActionResult CustomersSales(int id)
        {
            return View(this.customers.CustomerWithCars(id));
        }
    }
}