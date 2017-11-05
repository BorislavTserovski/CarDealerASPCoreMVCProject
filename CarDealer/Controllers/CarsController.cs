using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarDealer.Services;

namespace CarDealer.Controllers
{
    public class CarsController : Controller
    {
        private ICarService customers;

        public CarsController(ICarService customers)
        {
            this.customers = customers;
        }

        [Route("/cars/{make}")]
        public IActionResult AllByMake(string make)
        {
            return View(this.customers.AllByMake(make));
        }

        [Route("/cars/all/parts")]
        public IActionResult AllWithParts()
        {
            return View(this.customers.AllWithParts());
        }
    }
}