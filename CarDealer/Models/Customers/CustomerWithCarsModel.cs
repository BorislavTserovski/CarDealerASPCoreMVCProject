using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Models.Customers
{
    public class CustomerWithCarsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CarsBought { get; set; }

        public decimal MoneySpent { get; set; }
    }
}
