using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarDealer.Data;
using CarDealer.Services;

namespace CarDealer.Controllers
{
    public class PartsController : Controller
    {
        private readonly IPartService parts;

        public PartsController(IPartService parts)
        {
            this.parts = parts;
        }
        //GET
        public IActionResult All(int page)
        {
            return View(this.parts.All(page));
        }

       
        //GET
        public IActionResult Add()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Add(string name, decimal price, string supplierName, int? quantity)
        {
            this.parts.Add(name, price, supplierName, quantity);
            return RedirectToAction("/all");
        }
    }
}