using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarDealer.Services;

namespace CarDealer.Controllers
{
    public class SuppliersController : Controller
    {
       private readonly ISupplierService suppliers;

       public SuppliersController(ISupplierService suppliers)
        {
            this.suppliers = suppliers;  
        }

        [Route("/suppliers/{origin}")]
        public IActionResult SuppliersByPartsOrigin(string origin)
        {
            return View(suppliers.GetSuppliersByPartsOrigin(origin));
        }
    }
}