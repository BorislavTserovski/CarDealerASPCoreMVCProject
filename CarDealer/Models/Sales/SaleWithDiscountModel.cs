using CarDealer.Models.Cars;
using CarDealer.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Models.Sales
{
    public class SaleWithDiscountModel
    {
        public decimal PriceWithDiscount { get; set; }

        public decimal PriceWithoutDiscount { get; set; }

        public CarModel Car { get; set; }

        public CustomerModel Customer { get; set; }

    }
}
