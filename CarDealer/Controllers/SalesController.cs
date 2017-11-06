using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarDealer.Services;

namespace CarDealer.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISaleService sales;

        public SalesController(ISaleService sales)
        {
            this.sales = sales;
        }
        [Route("/sales")]
        public IActionResult All()
        {
            return View(this.sales.All());
        }

        [Route("/sales/{id}")]
        public IActionResult SaleById(int id)
        {
            return View(this.sales.SaleById(id));
        }

        [Route("/sales/discounted")]
        public IActionResult AllDiscounted()
        {
            return View(this.sales.DiscountedSales());
        }
    }
}